# WEB API

## Nasıl çalışır ?

```
dotnet watch
```

## Nasıl istek gönderilir ?

istek atabilmek için zorunlu bazı headerların kullanılması gerekir aşağıdaki rotaya uyarak hareket edebilirsiniz.

| Header Adı    | Veri tipi | Açıklama                                                                                                                                                                                                                                                                |
| ------------- | --------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| authorization | STRING    | ey... ile başalayan bir jwt tokeni olmalıdır. örnek : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJzZWZhIiwibmJmIjoxNzA0NDc2Mjk5LCJleHAiOjE3MDQ1NjI2OTksImlhdCI6MTcwNDQ3NjI5OSwiaXNzIjoic2VmYWNhbnBlaGxpdmFuLmNvbSJ9.T4fwOgzuOhRju_3zmMH6bMjL952OCt2aHCFaEXEYCoA\* **Not : Login, Register, GetAllProducts ve GetOneProduct için gerekli değildir !** |

### **Login**

```
POST /api/Users/Login
```

Bu endpoint kullanıcı girişi için kullanılmalı

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                                 |
| -------- | --------- | ---------- | -------------------------------------------------------- |
| email    | STRING    | EVET       | email formatında olmalı örn. example@example.com         |
| password | STRING    | EVET       | en az bir harf ve sayı kullanımı tavsiye edilir |

**Response:**

```javascript
    {
        accessToken: 'ey...',

        status code: 200 
    }
```

---

### **Register**

```
POST /api/Users/Register
```

Bu endpoint kullanıcı kaydı için kullanılmalı.

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                                 |
| -------- | --------- | ---------- | -------------------------------------------------------- |
| fullName   | STRING      | EVET       | kullanıcının ad soyad bilgisi girilmelidir                               |
| userName | STRING    | EVET       | bu veri eşşiz (unique) olmalıdır                         |
| email    | STRING    | EVET       | email formatında olmalı örn. example@example.com ,  eşşiz (unique) olmalıdır       |
| password | STRING    | EVET       | Bir büyük harf, bir küçük harf tavsiye edilir |

**Response:**

```javascript
{
         status code: 201 
    }
```

---

### **Create Product**

```
POST /api/Products/CreateProduct
```

Bu endpoint ürün oluşturmak için kullanılmalı.



**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                           |
| -------- | --------- | ---------- | -------------------------------------------------- |
| productId    | INT    | EVET       | Sistemde kayıtlı olmayan ve eşsiz bir ID olmalı |
| productName | STRING    | EVET       | Ürünün ad bilgisi                                       |
| price   | INT     | EVET       | Ürünün fiyat bilgisi                 |
| isActive   | BOOL     | EVET       | Ürünün yayında olup olmaması bilgisi                   |

**Response:**

```javascript
    {
        "productId": 11,
        "productName": "Samsung S16",
        "price": 25000,
        "isActive": true

        status code: 201
    }
```

### **Get All Products**

```
GET /api/Products/GetAllProducts
```

Bu endpoint databasedeki tüm ürünleri göstermek için kullanılmalı.

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                     |
| -------- | --------- | ---------- | -------------------------------------------- |
|          |           |            | Not : Bu bölümde parametreye ihtiyaç yoktur. |


**Response:**

```javascript
[
  {
    "productId": 1,
    "productName": "IPhone 11",
    "price": 60000
  },
  {
    "productId": 2,
    "productName": "IPhone 12",
    "price": 70000
  },
  {
    "productId": 4,
    "productName": "IPhone 14",
    "price": 90000
  },
  {
    "productId": 5,
    "productName": "IPhone 15",
    "price": 95000
  },
  {
    "productId": 6,
    "productName": "Samsung S20",
    "price": 30000
  },
  {
    "productId": 7,
    "productName": "Samsung S21",
    "price": 40000
  },
  {
    "productId": 8,
    "productName": "Samsung S22",
    "price": 50000
  },
  {
    "productId": 9,
    "productName": "Samsung S23",
    "price": 60000
  },
  {
    "productId": 10,
    "productName": "Samsung S24",
    "price": 70000
  },
  {
    "productId": 11,
    "productName": "Samsung S16",
    "price": 25000
  }

    status code: 200
]

```
### **Get One Products**

```
GET /api/Products/GetOneProduct/id
```

Bu endpoint databasedeki istenilen bir ürünü göstermek için kullanılmalı.

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                     |
| -------- | --------- | ---------- | -------------------------------------------- |
|     id     |     INT      |      EVET      | Gösterilmek istenen ürünün id bilgisi |


**Response:**

```javascript
{
  "productId": 1,
  "productName": "IPhone 11",
  "price": 60000

  status code: 200
}

```
### **Update Product**

```
PUT /api/Products/UpdateProduct/id
```

Bu endpoint databasedeki istenilen bir ürünün bilgilerini güncellemek için kullanılmalı.

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                     |
| -------- | --------- | ---------- | -------------------------------------------- |
| productId    | INT    | EVET       | Sistemde kayıtlı olmayan ve eşsiz bir ID olmalı |
| productName | STRING    | EVET       | Ürünün ad bilgisi                                       |
| price   | INT     | EVET       | Ürünün fiyat bilgisi                 |
| isActive   | BOOL     | EVET       | Ürünün yayında olup olmaması bilgisi                   |



**Response:**

```javascript
{
  status code: 204
}

```
### **Delete Product**

```
DELETE /api/Products/DeleteProduct/id
```

Bu endpoint databasedeki istenilen bir ürünü silmek için kullanılmalı.

**Parameters:**

| Veri adı | Veri tipi | Zorunluluk | Açıklama                                     |
| -------- | --------- | ---------- | -------------------------------------------- |
|          |           |            | Not : Bu bölümde parametreye ihtiyaç yoktur yalnızca url içinde silinmek istenen ürünün id'sinin gönderilmesi yeterlidir |



**Response:**

```javascript
{
  status code: 204
}

```
