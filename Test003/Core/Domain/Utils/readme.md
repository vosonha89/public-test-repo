# Domain Helpers

This directory contains helper and utility classes that provide common functionality for the domain layer. These helpers encapsulate reusable code that can be used across the domain model without introducing dependencies on external frameworks.

## Purpose

Domain helpers serve to:
- Reduce code duplication
- Encapsulate complex operations
- Provide domain-specific utility functions
- Keep the domain model clean and focused

## Available Helpers

### FunctionHelper

Provides utility functions for common operations:

- `StringToBase64`: Converts a string to its Base64 representation

### ObjectHelper

Provides utility functions for working with objects:

- Object comparison
- Type checking
- Object transformation

## Usage Guidelines

1. **Domain Focus**: Helpers should focus on domain-specific functionality
2. **Framework Independence**: Avoid dependencies on external frameworks or libraries
3. **Stateless**: Helpers should generally be stateless utility classes
4. **Well-Documented**: Include XML documentation for all helper methods
5. **Unit Tested**: Ensure all helper methods have corresponding unit tests

## Example

```csharp
// Using the StringToBase64 function from FunctionHelper
string base64String = FunctionHelper.StringToBase64("Hello World");
```

When adding new helper methods, ensure they align with domain requirements and maintain the architectural integrity of the application.
