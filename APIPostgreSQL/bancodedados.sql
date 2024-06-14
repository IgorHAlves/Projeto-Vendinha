create table cliente(
	id integer not null,
	nome varchar(100) not null,
	datanascimento date not null,
	email varchar(200)not null,
	divida integer
	
);

select * from cliente


insert into cliente (id,nome,datanascimento,email,divida) values (1,'jose','29/05/1998','jose@email.com',120)
insert into cliente (id,nome,datanascimento,email,divida) values (2,'joao','22/04/1999','joao@email.com',150);
insert into cliente (id,nome,datanascimento,email,divida) values (3,'jose','12/12/1966','maria@email.com',90)

select version();


alter table cliente 
add constraint clientes_pk primary key (id);

create table pedidos(
id_pedido integer primary key,
id integer,
situacao varchar(8),
datacriacao date default current_date,
datapagamento date,
descricao varchar(100)
)

insert into pedidos(id_pedido,id,situacao,datapagamento,descricao)
values(1,1,'Não pago','2024-06-17','Marcou duas Cocas')

select * from pedidos

alter table pedidos
add constraint pedidos_id_fk foreign key(id) references cliente(id);