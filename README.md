# TAL API Technical Test Solution
## API 
    - Calculate Monthly Preimium
    - Get list of Occupation
    
## Architecture
  - Clean Architecture
    - Core -- Contain Bussiness Logic, Domain Model
    - Infrastructure -- DataSource
    - Presentation -- API Controller
  - CQRS (Command Query Responsibility Segregation)
    - Provides code separation for complex structure, where each API endpoint require more handling, in terms of validation and service, and optimization.
    - MediatorR.
 - Automapper(object mapping)
 - Unit test (Xunit)
 
## How to run  
- Go to Presentation folder
- Set "TALTechChallenge.Api" as startup project .

## TODO :
- More Validations
- More Custom Exception handling 
- More unit tests
- Logging

Note: The sole purpose of the design is to demonstrate that CQRS can handle complex API. However other simpler patterns can be used in simpler use cases.
