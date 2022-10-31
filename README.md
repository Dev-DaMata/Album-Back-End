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
# 🛣️ Rotas

### ⚽ Times

- **GET /Times/getTimes**

Confira os times resgistrados no banco de dados

Esquema da requisição:

>https://localhost:7128/Times/getTimes

Esquema da resposta:

```json
[
  {
    "id_time": 2,
    "foto_brasao": "aHR0cHM6Ly93d3cuZ29vZ2xlLmNvbS91cmw/c2E9aSZ1cmw9aHR0cHMlM0ElMkYlMkZ3d3cuY29ycmVpb2JyYXppbGllbnNlLmNvbS5iciUyRmVzcG9ydGVzJTJGMjAyMiUyRjA4JTJGNTAzMDMxOS1jb20tY3JvbW9zLWVzcGVjaWFpcy1hbGJ1bS1kYS1jb3BhLTIwMjItY2hlZ2EtYXMtYmFuY2FzLW5lc3RhLXNleHRhLmh0bWwmcHNpZz1BT3ZWYXcyM00xVlEzZUNfOVpxaTY5R2dNeVptJnVzdD0xNjY3MDUzNDM3NjU3MDAwJnNvdXJjZT1pbWFnZXMmY2Q9dmZlJnZlZD0wQ0EwUWpSeHFGd29UQ0lDZ3VKR1FnX3NDRlFBQUFBQWRBQUFBQUJBRQ==",
    "nome_time": "Brasil"
  },
  {
    "id_time": 3,
    "foto_brasao": "aHR0cHM6Ly93d3cuZ29vZ2xlLmNvbS91cmw/c2E9aSZ1cmw9aHR0cHMlM0ElMkYlMkZwdC53aWtpcGVkaWEub3JnJTJGd2lraSUyRlNlbGUlMjVDMyUyNUE3JTI1QzMlMjVBM29fQ2F0YXJpX2RlX0Z1dGVib2wmcHNpZz1BT3ZWYXcxRnFWX2wzTjZLdGZhMTFvdTNXZkpkJnVzdD0xNjY3MzIwMTYxMzc1MDAwJnNvdXJjZT1pbWFnZXMmY2Q9dmZlJnZlZD0wQ0EwUWpSeHFGd29UQ0tDSmx1SHhpdnNDRlFBQUFBQWRBQUFBQUJBRQ==",
    "nome_time": "Qatar"
  }
]
```
⚠️ As imagens foram convertidas para base 64!

---
