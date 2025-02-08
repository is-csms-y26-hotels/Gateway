# Gateway - README  

## 📌 Description  
**Gateway Service** is the single entry point for all client interactions within the hotel booking system.  
It routes, orchestrates, and validates requests between users and internal microservices via **gRPC**

## 🚀 Features  
- **Routes client requests** to appropriate microservices  
- **Aggregates and formats responses**  
- **Handles synchronous (gRPC) interactions**

## 🔗 Service Interactions  
### Synchronous (gRPC):  
- **UserService** — User management (create users, fetch user info)  
- **AccommodationService** — Retrieve hotels and rooms  
- **BookingService** — Manage bookings (create, update, cancel)  

## 🔧 Architecture  
- **Language:** C#
- **gRPC API** for internal communication  

## 📜 Business Processes  

### ✅ **Create a User**  
1. Gateway validates the request and sends it to **UserService** via gRPC  
2. If successful, it returns a success response to the client  

### 🔍 **View Available Rooms**  
1. Gateway requests a list of hotels from **AccommodationService**  
2. Requests room details for a specific hotel  
3. Calls **BookingService** to check room availability  
4. Aggregates and returns the response  

### 🏨 **Book a Room**  
1. Gateway forwards the request to **BookingService**  
2. BookingService validates hotel & room existence via **AccommodationService**  
3. If valid, the booking is created  

### 🔄 **Modify a Booking**  
1. Gateway forwards the request to **BookingService**  
2. The system updates booking details  

### ❌ **Cancel a Booking**  
1. Gateway forwards the request to **BookingService**  
2. The booking is canceled  

## 📊 Future Enhancements  
- **Rate limiting & request throttling** for API protection  
- **Load balancing** for high scalability  
- **Logging & monitoring** (OpenTracing, Prometheus + Grafana)

## 👥 Team Members  
- 🏗 **Isaev Daniil** — Gateway  

