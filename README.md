Example application for using GraphQL with ASP.NET Core.

# Running locally
- Restore the Nuget Packages
- Update the Database to the latest migrations by executing `Update-Database` from the `Package Manager Console`
- Run the application, it should open on `ui/playground`

# Queries
The following queries are available:
```
query AllRooms {
  listRooms {
    id
    name
    status
    allowedSmoking
  }
}

query SmokingRooms {
  searchRooms(allowedSmoking: true) {
    id
    name
    status
    allowedSmoking
  }
}

query AvailableRooms {
  searchRooms(available: true) {
    id
    name
    status
    allowedSmoking
  }
}

query AvailableSmokingRooms {
  searchRooms(available: true allowedSmoking: true) {
    id
    name
    status
    allowedSmoking
  }
}

query SpecificRoom {
  getRoom(id: 3) {
    id
    name
    status
    allowedSmoking
  }
}

query ListReservations {
  listReservations {
    id
    guest {
      name
    }
    checkinDate
    checkoutDate
  }
}

```

# Mutations
Apart form queries, there are also a few mutations available
```
mutation CreateReservation {
  addReservation(reservation: {
    roomId: 3
    guestId: 1
    checkinDate: "2020-05-25"
    checkoutDate: "2020-05-26"
  }) {
    id
    guest {
      name
    }
    checkinDate
    checkoutDate
  }
}

mutation RemoveReservation {
  removeReservation(id: 4) {
    id
  }
}
```
