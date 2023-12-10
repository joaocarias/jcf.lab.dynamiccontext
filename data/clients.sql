Create database db_dc_clientone_dev;
create table db_dc_clientone_dev.reports 
(
    Id CHAR(36) PRIMARY KEY,
    MyClient VARCHAR(255) NOT NULL,
    MyText VARCHAR(255),
    MyTest VARCHAR(255)
);

insert into db_dc_clientone_dev.reports (Id, MyClient, MyText, MyTest) 
values 
(UUID(), 'Client One', 'My Text One', 'My Test One'),
(UUID(), 'Client One', 'My Text One - two', 'My Test One - two'),
(UUID(), 'Client One', 'My Text One - three', 'My Test One - three');

select * from db_dc_clientone_dev.reports;

Create database db_dc_clienttwo_dev;
create table db_dc_clienttwo_dev.reports 
(
    Id CHAR(36) PRIMARY KEY,
    MyClient VARCHAR(255) NOT NULL,
    MyText VARCHAR(255),
    MyTest VARCHAR(255)
);

insert into db_dc_clienttwo_dev.reports (Id, MyClient, MyText, MyTest) 
values 
(UUID(), 'Client Two', 'My Text Two', 'My Test Two'),
(UUID(), 'Client Two', 'My Text Two - two', 'My Test Two - two'),
(UUID(), 'Client Two', 'My Text Two - three', 'My Test Two - three'),
(UUID(), 'Client Two', 'My Text Two - four', 'My Test Two - four');

select * from db_dc_clienttwo_dev.reports;

