# Text Filter Function App 

This C# function HTTP trigger applies multiple text filters to a given string. It supports an extensible mechanism for adding various filters, based on different criteria.

## Features

- **Apply Multiple Filters using chain of responsibility** 
- **Extensible Design; Can implement a new filter and add it to the chain of responsibility**
- **Followed TDD approach**
- **Unit Tests**
- **Integration Tests**

## Prerequisites
- .NET 8

## Getting Started
1. Clone this repository:
    ```bash
    git clone https://github.com/marios-siatis/Calastone.TextFilter.git
    cd text-filter-app
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the unit tests:
    ```bash
    dotnet test

4. Run through IDE (Rider/VS) or cmd 