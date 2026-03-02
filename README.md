# QA Automation Portfolio – Playwright + NUnit (.NET)

## Overview

This project is a structured QA automation framework built with:

- Playwright (.NET)
- NUnit
- Page Object Model (POM)
- API + UI test separation
- Config-driven setup
- Screenshot capture on failure
- Parallel-ready architecture

---

## Architecture


Base/ → Test lifecycle & global setup
Pages/ → Page Object Model
Clients/ → API client abstraction
Configuration/ → Config management
Tests/ → UI & API tests


---

## Features

- Data-driven tests (NUnit TestCase)
- UI + API automation
- Global browser lifecycle management
- Screenshot capture on failure
- Configurable headless mode
- Clean separation of concerns

---

## How to Run

```bash
dotnet test
Technologies

.NET 10

Microsoft.Playwright

NUnit

HttpClient
