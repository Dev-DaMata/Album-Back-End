<h1> ⚠️ Status: :white_check_mark: </h1>

<h2 align="center">ALBUM DA COPA 2022 </h2>

## 💻 Tecnologias utilizadas:

- ASP.NET
- .NET CORE 
- C#
- DAPPER
- SQL SERVER

## 📜 Projeto:

Esse projeto consiste na criação de uma API voltada para o cadastro dos jogadores presentes no album da copa do ano de 2022

## 📦 Nugets

- DAPPER
- SQLCLIENT
- SWAGGER

## ⬇️ Instalação

Para utilizar este projeto de forma local, é necessário fazer um
`git clone` em sua máquina. Lembre-se de conferir de você possui os Nugets necessários.

Para clonar o repositório, digite no terminal da sua máquina:

```
https://github.com/Dev-DaMata/Album-Back-End.git
```

Acesse a pasta:
```
cd \source\repos\VeiculosBackEnd>Album-Copa
```

## 💾 Schema do MySQL SERVER
```
CREATE TABLE Figurinhas_copa (
    id_figurinha int NOT NULL PRIMARY KEY,
    foto VARBINARY(MAX),
    id_time int,
    CONSTRAINT FK_Atleta_Time FOREIGN KEY (id_time)
    REFERENCES Times(id_time),
    id_atleta int
    CONSTRAINT Atletas FOREIGN KEY (id_atleta)
    REFERENCES Atletas(id_atleta)
)

CREATE TABLE Atletas_copa (
    id_atleta int NOT NULL PRIMARY KEY ,
    nome varchar(255),
    foto VARBINARY(MAX),
    pais varchar(255),
    id_time int
    CONSTRAINT FK_Atleta_Time FOREIGN KEY (id_time)
    REFERENCES Times(id_time)
)
CREATE TABLE Times_copa (
    id_time int NOT NULL PRIMARY KEY ,
    foto_brasao VARBINARY(MAX),
    nome_time varchar(50)
)
```
