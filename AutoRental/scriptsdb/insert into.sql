USE AutoRental
GO

--select * from manufacturer
--Audi
insert into manufacturer values ('Honda','04337168000148', 13530900);
insert into manufacturer values ('Renout','00913443000173', 04260020);
insert into manufacturer values ('Volkswagen','59104422000150', 09823901);
insert into manufacturer values ('Fiat', '16701716000156', 03527907);
insert into manufacturer values ('Peugeot', '67405936000173', 13570390);
insert into manufacturer values ('Yamaha', '62934252000498', 06612250);
insert into manufacturer values ('Mitsubishi', '29192827000126', 01310915);
insert into manufacturer values ('Suzuki', '29031817000109', 08260110);
insert into manufacturer values ('Audi', '03472246000405', 18520101);
insert into manufacturer values ('Mercedes', '59104273000129', 05081060);
insert into manufacturer values ('Chevrolet', '59275792000150', 04062003);

--select * from auto																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																	
--Toyota Corola, Renout Logan, Volksvagen Jeta, Volksvagen Gol, Fiat Toro, Pegeout 5008,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             Tiida, Honda Civic
--Yamaha Fazer, Honda Tidan, Mitsubishi Kawasaki, Suzuki Hayabusa
--FMO1J44 - exemplo de placa
insert into auto values ('FMU0T55', (select id_manufacturer from manufacturer where name = 'Renout'), 'Logan', getdate());
insert into auto values ('REW0A40', (select id_manufacturer from manufacturer where name = 'Honda'), 'Civic', getdate());
insert into auto values ('EROPA30', (select id_manufacturer from manufacturer where name = 'Suzuki'), 'Kawasaki', getdate());

--select * from year

WITH YearList AS
(
    SELECT 1930 AS Year
    UNION ALL
    SELECT Year + 1
    FROM YearList
    WHERE Year + 1 <= YEAR(GETDATE())
)
INSERT INTO year (year)
SELECT Year
FROM YearList
ORDER BY Year;


