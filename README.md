# Example application for using GraphQL with ASP.NET Core.
![](https://github.com/frederikprijck/dotnetcore-graphql/workflows/Build/badge.svg)
## Running locally
- Restore the Nuget Packages
- Update the Database to the latest migrations by executing `Update-Database` from the `Package Manager Console`
- Run the application, it should open on `ui/playground`

## Queries
The following queries are available:
```
query AllRooms {
  listRooms {
    id
    name
    status
    hasWifi
  }
}

query WifiRooms {
  searchRooms(wifi: true) {
    id
    name
    status
    hasWifi
  }
}

query AvailableRooms {
  searchRooms(available: true) {
    id
    name
    status
    hasWifi
  }
}

query AvailableWifiRooms {
  searchRooms(available: true wifi: true) {
    id
    name
    status
    hasWifi
  }
}

query SpecificRoom {
  getRoom(id: 3) {
    id
    name
    status
    hasWifi
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

## Mutations
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
