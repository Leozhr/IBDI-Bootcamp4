# IBID | Bootcamp 4ª Edição

<br/>

Este é um projeto robusto desenvolvido em C# que oferece um sistema de gerenciamento de produtos com todas as operações essenciais de um CRUD (Create, Read, Update, Delete). Ele permite a criação, leitura, atualização e exclusão de registros de produtos de forma eficiente e organizada.

### Este projeto foi implantado com sucesso na plataforma Azure 🧑‍🚀:

<br/>
 
   <a href="https://ibidbootcamp4.azurewebsites.net/Pages/Index.aspx" target="_blank"><img src="https://img.shields.io/badge/-Clique Aqui para acessar o Projeto Online-26ae61?style=for-the-badge&logo=azure&logoColor=white" target="_blank"></a>
  
<br/>
 
 ## 🚀 Resultado
 <br/>
 
  <img width="" src="https://github.com/Leozhr/IBID-Bootcamp4/assets/117487925/c3fcf6c5-d1fb-4783-bd53-01ce2f0fc00d" />
    
  <br/>
      
  <img width="" src="https://github.com/Leozhr/IBID-Bootcamp4/assets/117487925/0d5c567f-a95f-47b6-be4d-88feadc4ef01" />
  
 <br/>
  
<br/>

## 💡 Construção
> O Projeto foi criado em C#, HTML, CSS, Javascript, Bootstrap

<br/>

Este é um projeto desenvolvido em C# seguindo o padrão .NET Web Forms. Ele oferece um sistema de gerenciamento de produtos, permitindo que você adicione, visualize, atualize e remova produtos de forma eficaz e organizada.

Este aplicativo foi construído com base nas práticas recomendadas de desenvolvimento em C# e segue o padrão .NET Web Forms, oferecendo uma experiência intuitiva para o gerenciamento de produtos. É uma ferramenta valiosa para o controle de estoque, oferecendo funcionalidades essenciais para atender às necessidades de gerenciamento de produtos em um ambiente de negócios.

<br />

## ✨ Instruções de Uso

> Siga estas etapas para utilizar o aplicativo de gerenciamento de produtos:

#### Clonar o Repositório:

Clone este repositório para o seu ambiente de desenvolvimento local usando o seguinte comando:

1 - ```git clone https://github.com/Leozhr/IBID-Bootcamp4```

2 - Abra a solução no ambiente de desenvolvimento C# de sua preferência (por exemplo, Visual Studio).

3 - Compile o projeto.

4 - Execute o aplicativo.

5 - Siga as instruções para interagir com o CRUD de produtos.

<br />

## 🧩 Banco de Dados (SQL Server Management Studio)

> O SQL utilizado está em nuvem na azure.

#### Estrutura da Tabela:

```
CREATE TABLE Products(
  ID INT IDENTITY(1,1)
  Produto VARCHAR(250)
  Valor VARCHAR(250)
)
 ```

#### Procedimento Armazenado:

Obtendo todos os produtos: **sp_load**

```
CREATE PROCEDURE sp_load
AS BEGIN
SELECT * FROM Products
END
```

Obtendo todos os produtos: **sp_create**

```
CREATE PROCEDURE sp_create
@Product VARCHAR(250),
@Valor VARCHAR(250)
AS BEGIN
INSERT INTO Products VALUES (@Product, @Valor)
END
```

Obtendo todos os produtos: **sp_read**

```
CREATE PROCEDURE sp_read
@ID INT
AS BEGIN
SELECT * FROM Products WHERE ID=@ID
END
```

Obtendo todos os produtos: **sp_update**

```
CREATE PROCEDURE sp_update
@ID INT,
@Product VARCHAR(250),
@Valor VARCHAR(250)
AS BEGIN
UPDATE Products SET Product=@Product, Valor=@Valor
WHERE ID=@ID
END
```

Obtendo todos os produtos: **sp_delete**

```
CREATE PROCEDURE sp_delete
@ID INT
AS BEGIN
DELETE FROM Products WHERE ID=@ID
END
```

 ## 🏆 Creditos
 
 <h3>Leonardo Leal @ 2023</h3>
