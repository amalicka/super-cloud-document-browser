select * from Document;

-- DocumentDoc
insert into DocumentDoc (Doc_ID, cp_revision, fontTable, theme, style)
values (36, 3, 'default', 'Aero', 'formal-presentation');

-- DocumentPdf
insert into DocumentPdf (Doc_ID, pageTree, outlineHierarchy, documentCatalog)
values (37, '0fc2e11a', '274cabff', 'default');

-- EditableField, Type in ('STRING', 'NUMBER', 'DATE')
insert into EditableField (Doc_ID, Name, Type, Value)
values (39, 'Miejsce zamieszkania', 'STRING', 'Warszawa');

-- Document
insert into Document (Name, Author, Type, Size, Content)
values ('Moj Doc', 'Ola', 'doc', 100, 'zawartsoc i tresc')
insert into Document (Name, Author, Type, Size, Content)
values ('Moj dokument', 'Ola', 'pdf', 100, 'zawartsoc i tresc')