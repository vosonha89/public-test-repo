# Base Classes

This directory contains base and abstract classes that provide common functionality and structure for the domain objects throughout the application.

## Purpose

Base classes serve to:
- Eliminate code duplication across similar entity types
- Enforce consistent patterns and behaviors
- Provide reusable functionality for domain objects
- Establish contracts that derived classes must fulfill

## Common Base Classes

### Entity Base

Provides fundamental entity capabilities:
- Identity management
- Basic equality comparison
- Core entity lifecycle properties (e.g., creation/modification timestamps)

### Value Object Base

Implements common value object functionality:
- Equality based on property values rather than reference
- Immutability enforcement
- Common validation patterns

### Aggregate Root Base

Extends the entity base class with additional features for aggregate roots:
- Domain event management
- Invariant validation
- Lifecycle management for the aggregate

## Usage Guidelines

1. **Minimal Implementation**: Keep base classes focused on essential shared behavior
2. **Avoid Deep Hierarchies**: Prefer composition over deep inheritance hierarchies
3. **Generic Parameters**: Use generic parameters to ensure type safety where appropriate
4. **Protected Methods**: Provide protected helper methods for derived classes
5. **Abstract Methods**: Use abstract methods to enforce implementation of critical functionality

## Best Practices

- Focus on behavior that is truly common across all derived types
- Avoid adding properties or methods that only apply to some derived classes
- Consider using interfaces alongside base classes for more flexible contracts
- Document expected usage patterns and responsibilities of derived classes
- Include XML documentation for all public and protected members

When extending base classes, ensure you understand the contract they establish and maintain consistency with the domain model.
