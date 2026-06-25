# API de Cancelamento de Pedidos

## 📌 Descrição

API REST desenvolvida em .NET 10 para gerenciamento e cancelamento de pedidos em um cenário de e-commerce.

O sistema aplica regras de negócio onde um pedido só pode ser cancelado se ainda não foi faturado.

---

## 🚀 Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- MySQL

---

## ⚙️ Como rodar o projeto

### ✅ Pré-requisitos

- .NET 10 SDK
- MySQL instalado
- Visual Studio

---

### ✅ Passo a passo

1. Clone o repositório

---

2. Configure a connection string usando **User Secrets pelo Visual Studio**:

- Clique com botão direito no projeto  
- Clique em **Gerenciar Segredos do Usuário**  
- No arquivo `secrets.json` que abrir, adicione:
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=PedidosDb;user=SEU_USUARIO;password=SUA_SENHA;"
  }
}
```
> ⚠️ A string de conexão não está no repositório por questões de segurança.

---

3. Aplique as migrations:

`Update-Database`

---

4. Execute o projeto:

`dotnet run`

---

## 🧪 Testes com Postman

Utilize o Postman para testar os endpoints.

### 🔹 Listar pedidos
GET http://localhost:<porta>/api/orders

---

### 🔹 Buscar pedido por ID
GET http://localhost:<porta>/api/orders/{orderId}

---

### 🔹 Cancelar pedido
POST http://localhost:<porta>/api/orders/{orderId}/cancel

---

## 📋 Regras de negócio

✅ Pode cancelar:
- ORDER_PLACED
- PAYMENT_PENDING
- PAYMENT_APPROVED
- READY_FOR_HANDLING
- HANDLING

❌ Não pode cancelar:
- INVOICED
- CANCELED

---

## ❗ Tratamento de erros

Formato padrão:
```
{
  "erro": "Mensagem de erro",
  "status": 000,
  "timestamp": "YYYY-MM-DDTHH:mm:ssZ"
}
```
---
