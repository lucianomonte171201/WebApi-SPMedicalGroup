use Senai_SPMedicalGroup

--TIPO_USUARIOS
select * from Tipo_Usuarios

insert into Tipo_Usuarios(Nome)
values ('Admin'),('Medico'),('Paciente')

update Tipo_Usuarios set Nome = 'Administrador' where ID = 1

--INSERT USUARIOS
insert into Usuarios(Email,Senha,Id_Tipo)
values ('admin@spmedgroup.com','******',1)
,('helena@spmedgroup.com','******',2)
,('fernando@spmedgroup.com','******',2)
,('carlos@spmedgroup','******',2)
,('joao@paciente.com','******',3)
,('juliana@paciente.com','******',3)

select * from Usuarios

-- INSERT CLINICA
insert into Clinica(Nome,CNPJ,Razao_Social,Endereco)
values ('Clínica Possarle','86400902000130','SP Medical Group','Av. Barão Limeira, 532, São Paulo, SP')

select * from Clinica

--INSERT ESPECIALIDADES 
insert into Especialidades(Nome)
values ('Odontologia'),('Pediatria'),('Psiquiatria')

select * from Especialidades

--INSERT MEDICOS
insert into Medicos(Nome,CRM,Id_Especialidade,Id_Usuario)
values ('Fernando','54356SP',3,7),('Carlos','53465SP',3,8),('Helena','32764SP',1,6)

select * from Medicos

--UPDATE NO NOME DO MÉDICO
update Medicos set Nome = 'Fernando Henrique' where Id_Usuario = 7

--INSERT ENDERECO_PACIENTE
insert into Endereco_Paciente(Estado,Cidade,Endereco,CEP)
values ('SP','São Paulo','Penha de França','01918013')
,('SP','Guarulhos','Bosque Maia','02715018')
,('SP','São Paulo','Eng. Goulart','01314021')

select * from Endereco_Paciente

--INSERT PRONTUARIO_PACIENTE 
insert into Prontuario_Paciente(Nome,RG,CPF,Data_Nascimento,Tel,Id_Usuario,Id_Endereco)
values ('João da Silva','508562233','54834532103','24/10/1993','11949882317',9,2)
,('Juliana Oliveira','504563214','47622112307','16/07/1996','11999352312',10,3)

select * from Prontuario_Paciente

--INSERT CONSULTA
insert into Consulta(Id_Prontuario,Id_Medico,Data_Consulta,Status_Consulta)
values (1,2,'22/02/2019','Agendada'),(2,3,'15/03/2019','Cancelada')

select * from Consulta

--DELETANDO CONSULTA CANCELADA
delete from Consulta where Id_Prontuario = 2



drop table Clinica

