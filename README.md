# **ResourceBroker**

This repository contains the implementation of a **Package Optimization System** using the **Grey Wolf Optimizer (GWO)** algorithm. The project aims to group available resources (e.g., CPU, GPU, RAM, etc.) into optimal packages based on multi-criteria evaluation such as cost, capacity, diversity, and availability. 

The project also utilizes **Dependency Injection (DI)** design pattern to enhance flexibility, maintainability, and testability. Additionally, it includes features to generate graphical reports as final outputs.

---

## **Key Features**
- **Grey Wolf Optimizer (GWO):**
  - Inspired by the hunting behavior of grey wolves.
  - Iteratively refines resource allocation to form optimal packages.
  - Ranks "wolves" (candidate packages) based on a multi-criteria fitness function.

- **Multi-Criteria Optimization:**
  - Positive Criteria: Capacity, diversity, availability, service consistency, upload/download bandwidth.
  - Negative Criteria: Cost, response time.
  - Weighted scoring mechanism to compute package fitness.

- **Dependency Injection (DI):**
  - Simplifies dependency management for better modularity and scalability.

- **Graphical Reporting:**
  - Outputs visual reports (charts, graphs) showing performance metrics such as efficiency, complexity, and resource utilization.

---

## **Tech Stack**
- **Programming Language:** C#
- **Framework:** .NET Core
- **Design Pattern:** Dependency Injection (DI)

---

## **Usage**

### **1. Prerequisites**
- .NET Core SDK installed on your system.
- A dataset of resources with details such as type, capacity, cost, response time, and service characteristics.

### **2. Installation**
1. Clone the repository:
   ```bash
   git clone https://github.com/MortezaHosseyni/ResourceBroker.git
   cd ResourceBroker
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

### **3. Running the Project**
Run the application with the following command:
```bash
dotnet run
```

You can configure input data (resource types and properties) in the appropriate file or database configuration.

---

## **System Workflow**
1. **Resource Filtering:**
   - Filters unallocated resources to prepare input for the optimization algorithm.

2. **Initialization:**
   - Initializes the wolf population (candidate packages) with random resource allocations.

3. **Optimization:**
   - Iteratively refines packages by simulating wolf hunting behavior.
   - Updates wolf positions based on alpha, beta, and delta wolves (the top-ranked solutions).

4. **Selection:**
   - Selects the best packages based on fitness scores.
   - Ensures no resource is reused across packages.

5. **Graphical Reports:**
   - Generates charts and graphs summarizing the optimization results.

---

## **Scoring Criteria**
The fitness function evaluates packages based on:
- **Positive Criteria:**
  - Resource diversity
  - Resource availability
  - Service consistency
  - Capacity, upload, and download bandwidth
- **Negative Criteria:**
  - Response time
  - Cost
- **Additional Factors:**
  - Efficiency and complexity of resource utilization.
