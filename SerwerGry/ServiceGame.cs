using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Kontrakt;
using System.Data.SqlClient;

namespace SerwerGry {
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class ServiceGame : IServiceGame {

        private const string CONNECTOIN_STRING = @"Data Source=(LocalDB)\v11.0;
                                AttachDbFilename = C:\Users\Aleksandra\Desktop\JPP_W_Ptasznik\SerwerGry\SerwerGry\DocumentDB.mdf;
                                MultipleActiveResultSets=True;
                                Connect Timeout=30;";

        private const string DOC_HTML = "html";
        private const string DOC_PDF = "pdf";
        private const string DOC_DOC = "doc";

        private const string SQL_SELECT_DOCS = "select Id, Name, Author, Type, Size, Content from Document;";
        private const int ID_IDX = 0;
        private const int NAME_IDX = 1;
        private const int AUTHOR_IDX = 2;
        private const int TYPE_IDX = 3;
        private const int SIZE_IDX = 4;
        private const int CONTENT_IDX = 5;

        private const string SQL_SELECT_DOC_PROPS = "select cp_revision, fontTable, theme, style from DocumentDoc where Doc_ID = {0};";
        private const int CP_REVISION_IDX = 0;
        private const int FONT_TABLE_IDX = 1;
        private const int THEME_IDX = 2;
        private const int STYLE_IDX = 3;

        private const string SQL_SELECT_PDF_PROPS = "select pageTree, outlineHierarchy, documentCatalog from DocumentPdf where Doc_ID = {0}";
        private const int PAGE_TREE_IDX = 0;
        private const int OUTLINE_HIERARCHY_IDX = 1;
        private const int DOCUMENT_CATALOG_IDX = 2;

        private const string SQL_SELECT_EDITABLE_FIELDS = "select Name, Type, Value from EditableField where Doc_ID = {0}";
        private const int EDITABLE_NAME_IDX = 0;
        private const int EDITABLE_TYPE_IDX = 1;
        private const int EDITABLE_VALUE_IDX = 2;

        private const string SQL_INSERT_DOC = "insert into Document (Name, Author, Type, Content) values ('{0}', '{1}', '{2}', '{3}');";
        private const string SQL_DELETE_DOC = "delete from Document where Id = {0}";

        public ServiceGame() {}

        public Document[] GetDocumentsList() {

            // Wyciagnij liste dokumentow
            // Challenge 1: tylko z tabelki Document (bez editable i parametow PDF/DOC)
            //      UWAGA: TYP dokumentu -> odpowiednia klasa!!!
            // Challenge 2: dodaj editable fieldsy
//            // Challenge 3: dodaj parametry dokumentow (tabelki PDF i DOC)
            try {
                List<Document> documentList = new List<Document>();
                SqlConnection con = new SqlConnection(CONNECTOIN_STRING);
                SqlDataReader documentReader = null;
                con.Open();
                Console.WriteLine("#### Connected to Database ####");
                SqlCommand cmd = new SqlCommand(SQL_SELECT_DOCS, con);
                documentReader = cmd.ExecuteReader();
                while (documentReader.Read()) {
                    Document document;

                    // Stworz dokument uzywajac odpowiedniej klasy dziedziczacej po Document
                    switch (documentReader[TYPE_IDX].ToString()) {
                        case DOC_DOC: {
                                // Wczytaj atrybuty specyficzne dla klasy DOC
                                DocumentDoc docDoc = new DocumentDoc();
                                SqlCommand sqlDocPropsCmd = new SqlCommand(
                                        String.Format(SQL_SELECT_DOC_PROPS, documentReader.GetInt32(ID_IDX)),
                                        con);
                                SqlDataReader docPropsReader = sqlDocPropsCmd.ExecuteReader();
                                if (docPropsReader.Read()) {
                                    docDoc.cp_revision = docPropsReader.GetInt32(CP_REVISION_IDX);
                                    docDoc.fontTable = docPropsReader[FONT_TABLE_IDX].ToString();
                                    docDoc.theme = docPropsReader[THEME_IDX].ToString();
                                    docDoc.style = docPropsReader[STYLE_IDX].ToString();
                                }
                                document = docDoc;
                                break;
                            }
                        case DOC_HTML:
                            document = new DocumentHtml();
                            // DocumentHtml nie ma specyficznych atrybutow
                            break;
                        case DOC_PDF: {
                                // Wczytaj atrybuty specyficzne dla klasy PDF
                                DocumentPdf docPdf = new DocumentPdf();
                                SqlCommand sqlPdfPropsCmd = new SqlCommand(
                                        String.Format(SQL_SELECT_PDF_PROPS, documentReader.GetInt32(ID_IDX)),
                                        con);
                                SqlDataReader pdfPropsReader = sqlPdfPropsCmd.ExecuteReader();
                                if (pdfPropsReader.Read()) {
                                    docPdf.pageTree = pdfPropsReader[PAGE_TREE_IDX].ToString();
                                    docPdf.outlineHierarchy = pdfPropsReader[OUTLINE_HIERARCHY_IDX].ToString();
                                    docPdf.documentCatalog = pdfPropsReader[DOCUMENT_CATALOG_IDX].ToString();
                                }
                                document = docPdf;
                                break;
                            }
                        default:
                            throw new InvalidCastException("Invalid document type from DB: " + documentReader[TYPE_IDX]);
                    }

                    // Jak juz mamy dokument, poustawiajmy mu reszte pol
                    document.Name = documentReader[NAME_IDX].ToString();
                    document.Author = documentReader[AUTHOR_IDX].ToString();
                    document.Id = documentReader.GetInt32(ID_IDX);

                    String sizeStr = documentReader[SIZE_IDX].ToString();
                    if (sizeStr != null && sizeStr != "") {
                        document.Size = Convert.ToDouble(sizeStr);
                    }

                    // EditableContent (czy zwykly Content?)
                    // Sprawdz czy dokument ma EditableFieldsy w bazie danych
                    SqlCommand sqlEditableFieldsCmd = new SqlCommand(
                            String.Format(SQL_SELECT_EDITABLE_FIELDS, documentReader.GetInt32(ID_IDX)),
                            con);
                    SqlDataReader editableFieldsReader = sqlEditableFieldsCmd.ExecuteReader();
                    EditableContent editableContent = null;
                    while (editableFieldsReader.Read()) {
                        // Jesli weszlismy -> document ma editable content, stworz i przypnij!
                        if (editableContent == null) {
                            editableContent = new EditableContent(
                                documentReader[CONTENT_IDX].ToString(),
                                new List<EditableField>());
                            document.Content = editableContent;
                        }
                        EditableField field = new EditableField();
                        field.Name = editableFieldsReader[EDITABLE_NAME_IDX].ToString();
                        field.Value = editableFieldsReader[EDITABLE_VALUE_IDX].ToString();
                        // Mapowanie ENUM -> baza danych
                        switch (editableFieldsReader[EDITABLE_TYPE_IDX].ToString()) {
                            case EditableField.TYPE_STRING:
                                field.FieldType = FieldType.STRING;
                                break;
                            case EditableField.TYPE_NUMBER:
                                field.FieldType = FieldType.NUMBER;
                                break;
                            case EditableField.TYPE_DATE:
                                field.FieldType = FieldType.DATE;
                                break;
                        }

                        // Dodaj editableField do editableContent
                        editableContent.EditableFields.Add(field);
                    }

                    // Ustaw content (jesli byl editable content, jest juz wpiety w dokument)
                    document.Content.DocContent = documentReader[CONTENT_IDX].ToString();

                    // Na koncu - dodaj dokument do listy
                    documentList.Add(document);
                }
                con.Close();
                Console.WriteLine("#### Accessing documents ####");
                foreach (var doc in documentList) {
                    Console.WriteLine("Name: " + doc.Name + ", author: " + doc.Author + ", size: " + doc.Size);
                }
                Console.WriteLine("#### DONE ####");

                return documentList.ToArray();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        public void AddDocument(Document newDoc) {
            Console.WriteLine("metoda: AddDocument");
            // Insert nowego dokumentu
            // Challenge 1: do tabelki Document
            // Nie mozna edytowac EditableField-sow, wiec nie trzeba wrzucac danych do tej tabelki
            // Nie mozna edytowac specyficznych parametrow PDF/DOC, wiec pomijamy
            SqlConnection con = new SqlConnection(CONNECTOIN_STRING);
            con.Open();  
          
            string type;
            if (newDoc.GetType() == typeof(DocumentPdf)) {
                Console.WriteLine("to jest pdf");
                type = "pdf";
            } else if (newDoc.GetType() == typeof(DocumentDoc)) {
                Console.WriteLine("to jest doc");
                type = "doc";
            } else if (newDoc.GetType() == typeof(DocumentHtml)) {
                Console.WriteLine("to jest html");
                type = "html";
            } else {
                Console.WriteLine("to jest unnown");
                type = "unnown";
            }

            SqlCommand cmd = new SqlCommand(
                String.Format(SQL_INSERT_DOC, newDoc.Name, newDoc.Author, type, newDoc.Content.DocContent), 
                con);
            int nmbrAffected =  cmd.ExecuteNonQuery();
            Console.WriteLine("#### Number of rows affected: " + nmbrAffected);
            con.Close();
            
            //Console.WriteLine("**************************\nDodano dokument wprowadzony przez usera:");
            //Console.WriteLine(newDoc.Name + " " + newDoc.Author + " " + newDoc.Content.DocContent);
        }

        public void RemoveDocument(Document delDoc) {
            // Delete wybranego dokumentu, po ID dokumentu
            Console.WriteLine("#### Searching for document to delete ####");
            SqlConnection con = new SqlConnection(CONNECTOIN_STRING);
            con.Open();
            SqlCommand deleteCommand = new SqlCommand(String.Format(SQL_DELETE_DOC, delDoc.Id), con);
            Console.WriteLine("Del str: " + String.Format(SQL_DELETE_DOC, delDoc.Id));
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Deleted: " + rowsAffected + " lines.");
            con.Close();
        }
    }
}
