# Dotnet Performance Test Garbage Collector

## About

This project was developed to test how the garbage collector affects system performance and how to exemplify how to write more performant code.

A cpf validate function was used, executed 1,500,000 times and written in three different forms of code, each one more performant than the other.

It is noticed when the less garbage collector is used, the more performant the code is.

Tests were run on a machine with:

- Win11
- Processor: i7
- Ram: 16gb

Validation V1:

```
Total time: 1104ms
GC Gen 0: 103
GC Gen 1: 1
GC Gen 2: 0
```

Validation V2:

```
Total time: 605ms
GC Gen 0: 23
GC Gen 1: 1
GC Gen 2: 0
```

Validation V3:

```
Total time: 319ms
GC Gen 0: 0
GC Gen 1: 0
GC Gen 2: 0
```
