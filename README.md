# ![pokedex](https://github.com/user-attachments/assets/d21036f0-18b3-4dd0-95b6-4223098b815b)

_Your portal to Pokémon data and epic translations!_

---

### **Features**
- 📋 **Pokémon Information**: Retrieve detailed data such as name, type, and habitat.
- 🌐 **Translations**: Get Pokémon descriptions translated into Shakespearean or Yoda styles.
- 🛠️ **API Documentation**: Swagger UI support for easy exploration.
- 🐳 **Docker Integration**: Deploy effortlessly using Docker.

---

### **Quick Start**

#### **Prerequisites**
- **.NET 8.0 SDK**
- **Docker** (Optional)

#### **Installation**
1. **Clone the repository**:
   ```bash
   git clone https://github.com/tammam14/PokeDex.git
   cd PokeDex

2. **Restore dependencies**:
   ```bash
   dotnet restore

3. **Build the project**:
   ```bash
   dotnet build


#### **Running the Application**
- To run the project locally:
   ```bash  
   dotnet run

- Once running, access the API documentation via Swagger:
   ```bash  
   http://localhost:8080/swagger
   
#### **Docker Setup**
- **Build the Docker image**:
   ```bash  
   docker build -t pokedexapi .

- **Run the Docker container**:
   ```bash  
   docker run -d -p 8080:8080 pokedexapi

#### **Key endpoints**
- **Get Pokémon Info**:
   ```bash  
   GET /api/pokemon/{name}
   Example: http://localhost:8080/api/pokemon/mewtwo

- **Get Translated Pokémon Description**:
   ```bash  
   GET /api/pokemon/translated/{name}
   Example: http://localhost:8080/api/pokemon/translated/pikachu

### **Feedback**
We'd love to hear your thoughts! Open an issue or send your feedback to my [GitHub](https://github.com/tammam14)
   
