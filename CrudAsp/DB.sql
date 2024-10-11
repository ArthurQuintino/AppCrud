create database dbBancoApp;
use dbBancoApp;
create table usuario(
IdUsu int primary key auto_increment,
nomeUsu varchar(50) not null,
Cargo varchar(50) not null, 
DataNasc datetime
);

insert into usuario(nomeUsu, Cargo, DataNasc)
				values('arthur', 'auxiliar', '1978/02/01'),
					  ('greik', 'gerente', '1980/02/01');
                      
                      
select * from usuario;


create table cliente(
IdCliente int primary key auto_increment, 
nomeCli varchar(50) not null,
emailCli varchar(70) not null,
TeleCli bigint not null,
EndCli varchar(90)
);

insert into cliente(NomeCli, EmailCli, TeleCli, EndCli)
				values('arthur', 'sla@gmail.com', '11980800808', 'rua nao sei');
                
                                      
select * from cliente;
     