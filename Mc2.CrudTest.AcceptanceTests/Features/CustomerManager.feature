Feature: Create List Edit Delete Customer

    Background:
        Given system error codes are following
          | Code | Description                                                |
          | 101  | Invalid Mobile Number                                      |
          | 102  | Invalid Email address                                      |
          | 103  | Invalid Bank Account Number                                |
          | 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 202  | Duplicate customer by Email address                        |
    
    @ignore
    Scenario: User Creates, List, Edit, Delete a Customer
        Given platform has "0" customers
		    When user creates a customer with following data by sending 'Create Customer Command' through API
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then the user can query to get all customers and must have "1" records with below details
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        When user creates a customer with following data by sending 'Create Customer Command' through API
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then the user must get errors
          | Code |
          | 201  |
          | 202  |
        When user edit customer by email "john@doe.com" with new data
          | FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
          | Jane      | William  | jane@william.com | +31612345678 | 01-FEB-2010 | IR000000000000002 |
        Then the user can query to get all customers and must have "0" records with below details
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        And the user can query to get all customers and must have "1" records with below details
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
           | Jane      | William  | jane@william.com | +31612345678 | 01-FEB-2010 | IR000000000000002 |
        When user delete customer by Email of "jane@william.com"
		    Then user can query to get all customers and get "0" records