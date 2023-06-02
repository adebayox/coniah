# Accounting package built using C#/.Net

# API Collection Description

This API collection provides endpoints for;
Generate report that shows debts over a period of time
Generate report that shows all debtors

The endpoints are as follows:

---

## API Endpoints

- **GET /api/Debt/GetAll**: Showa all debts.
- **POST /api/Debt/add-debtor**: Adds new debt/debtor.
- **PUT /api/Debt/edit-debtor-info**: Update an existing debt/debtor.
- **GET /api/Debt/GetReport?startDate&endDate**: Retrieves a report containing information of debts/debtors within a given period.

    

---

Please refer to the individual API endpoints for more detailed information on their usage, request parameters, and response formats.

## GET http://localhost:5052/api/Debt/GetAll
```
http://localhost:5052/api/Debt/GetAll
```

Description: Retrieves a list of all debts/debtors..

Method: GET

Returns: A list of all debts/debtors.

## POST http://localhost:5052/api/Debt/add-debtor
```
http://localhost:5052/api/Debt/add-debtor
```

Description: Adds a new debt/debtor.

Method: POST

Request Body: Contains the necessary data to assign the laptop (e.g., user information, laptop details).
```
{
{
  "debtor_Name": "king solomon",
  "amount": "9000",
  "phone_Number": "0812436312",
  "goods_Purchased": "Butter",
  "createdAt": "2023-04-02T22:05:22.339Z"
}
}
```

## PUT http://localhost:5052/api/Debt/edit-debtor-info
```
http://localhost:5052/api/Debt/edit-debtor-info
```

Description: Updates the details of a debtor.

Method: PUT

Request Body: Contains the updated information for an assigned debtor.
```
{
  "id": 1,
  "debtor_Name": "oluseye",
  "amount": "3000",
  "phone_Number": "0825681",
  "goods_Purchased": "purse",
  "createdAt": "2023-06-02T22:40:10.785Z"
}
```

## GET http://localhost:5052/api/Debt/GetReport?startDate&endDate=
```
http://localhost:5052/api/Debt/GetReport?startDate=2023/01/01&endDate=2023/08/01
```
Description: Retrieves a report containing information about all debtors.

Method: GET
```
Query Params
startDate
2023/1/01

endDate
2023/12/31
```


