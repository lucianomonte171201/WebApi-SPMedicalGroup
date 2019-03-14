use Senai_SPMedicalGroup

create table Tipo_Usuarios(
	ID int identity primary key
	,Nome varchar(250) not null unique
);

create table Usuarios(
	ID int identity primary key
	,Email varchar (250) not null unique
	,Senha varchar(100) not null
	,Id_Tipo int not null foreign key references Tipo_Usuarios(ID)
);


create table Especialidades(
	ID int identity primary key
	,Nome varchar(250) not null unique
);

create table Medicos(
	ID int identity primary key
	,Nome varchar(250) not null
	,CRM varchar (100) not null unique
	,Id_Especialidade int not null foreign key references Especialidades(ID)
	,Id_Usuario int not null foreign key references Usuarios(ID)
);

create table Endereco_Paciente(
	ID int identity primary key
	,Estado char(2) not null
	,Cidade varchar (250) not null
	,Endereco varchar(250) not null
	,CEP char(8) not null
);

create table Prontuario_Paciente(
	ID int identity primary key
	,Nome varchar(250) not null
	,RG char(9) not null unique
	,CPF char(11) not null unique
	,Data_Nascimento date not null
	,Tel varchar(100) not null unique
	,Id_Usuario int not null foreign key references Usuarios(ID)
	,Id_Endereco int not null foreign key references Endereco_Paciente(ID)
);

create table Consulta(
	ID int identity primary key
	,Id_Prontuario int not null foreign key references Prontuario_Paciente (ID)
	,Id_Medico int not null foreign key references Medicos (ID)
	,Data_Consulta date not null
	,Status_Consulta varchar (250) not null
);

create table Clinica(
	ID int identity primary key
	,Nome varchar(250) not null
	,CNPJ char(14) not null unique
	,Razao_Social varchar(250) not null
	,Endereco varchar (255) not null
);
