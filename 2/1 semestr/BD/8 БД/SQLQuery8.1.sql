USE University
ALTER TABLE Table_Grupa
ADD CONSTRAINT FK_ID_Kafedra
Foreign key (ID_Kafedra) references Table_Kafedra(ID_Kafedra)
GO
ALTER TABLE Table_Student
ADD CONSTRAINT FK_ID_Grupa
Foreign key (ID_Grupa) references Table_Grupa(ID_Grupa)