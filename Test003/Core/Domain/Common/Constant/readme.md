# Domain Constants

This directory contains constant definitions that are used throughout the domain layer. These constants provide centralized definitions for important domain values, error codes, status codes, and other invariant values.

## Purpose

Domain constants serve to:
- Eliminate magic strings and numbers in the codebase
- Provide a single source of truth for important domain values
- Ensure consistency across the application
- Make the code more maintainable and self-documenting

## Types of Constants

### Error Codes and Messages

The `GlobalError` class defines standardized error codes and messages used across the application:
- Consistent error identification
- Localization-friendly error messages
- Categorized error types

### Status Codes

Definitions for various status values in the domain:
- Entity states
- Process stages
- Request statuses

### Configuration Constants

Default and boundary values for configuration:
- Timeout values
- Retry counts
- Size limits
- Threshold values

### Domain-Specific Enumerations

Enumerated values specific to the domain:
- Types and categories
- States and stages
- Priorities and severities

## Implementation Guidelines

1. **Categorization**: Group related constants in separate files or classes
2. **Naming Conventions**: Use clear, descriptive names with appropriate prefixes
3. **Documentation**: Document the meaning and usage of each constant
4. **Immutability**: Ensure constants are truly constant (readonly or static readonly)

## Best Practices

- Use enums for related sets of values where appropriate
- Include descriptive XML comments for all constants
- Consider using static classes for grouping related constants
- Define string constants for any strings used in more than one location
- For localization, consider using resource files alongside constants

When adding new constants, ensure they belong in the domain layer rather than in infrastructure or application layers.
