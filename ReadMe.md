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

4. Run through IDE (Rider/VS) or cmd.
Alternatively, navigate on the root folder `src/Calastone.TextFilter` where `host.json` exists and run on cmd using the following command

```
func host start --pause-on-error --port 7209
```

Then hit the url `http://localhost:<port>/api/FilterTextHttpTrigger` to trigger the function.

<img width="928" alt="image" src="https://github.com/user-attachments/assets/22127c52-09bc-44f7-91f4-82c9172828ef">
