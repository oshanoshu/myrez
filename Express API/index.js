const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const { pool } = require('./config')

const app = express()

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: true }))
app.use(cors())

//API to get all the login details
const getUsers = (request, response) => {
  pool.query('SELECT * FROM LoginSignUp', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//API to get all the mock users
const getMockUsers = (request, response) => {
  pool.query('SELECT * FROM mockUsers', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}
//API to add new login details
const addUser = (request, response) => {
  const { Username, Password, Role } = request.body

  pool.query('INSERT INTO LoginSignUp (Username, Password, Role) VALUES ($1, $2, $3)', [Username, Password, Role], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'User added.' })
  })
}

//API to post new admin
const signAdminUser = (request, response) => {
  const { Name, Email, PhoneNumber, Major, Address, Building, Username} = request.body

  pool.query('INSERT INTO Administrators (Name, Email, PhoneNumber, Major, Address, Building, Username) VALUES ($1, $2, $3, $4, $5, $6, $7)', [Name, Email, PhoneNumber, Major, Address, Building, Username], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'Admin added.' })
  })
}

//Api to get all the admin users
const getAdminUsers = (request, response) => {
  pool.query('SELECT * FROM administrators', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//API to post new resident
const signResidentUser = (request, response) => {
  const { Name, Email, PhoneNumber, Major, Address, Building, Username, EmergencyContact, RoomNumber} = request.body

  pool.query('INSERT INTO Residents (Name, Email, PhoneNumber, Major, Address, Building, Username, EmergencyContact, RoomNumber) VALUES ($1, $2, $3, $4, $5, $6, $7,$8,$9)', [Name, Email, PhoneNumber, Major, Address, Building, Username, EmergencyContact, RoomNumber], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'Resident added.' })
  })
}


//Api to get all the resident users
const getResidentUsers = (request, response) => {
  pool.query('SELECT * FROM residents', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//API to post new discussion
const postNewDiscussion = (request, response) => {
  const { DiscussionTitle, DiscussionBody, DiscussionTime, ResID} = request.body

  pool.query('INSERT INTO Discussions (DiscussionTitle,DiscussionBody, DiscussionTime, ResID) VALUES ($1, $2, $3, $4)', [DiscussionTitle,DiscussionBody, DiscussionTime, ResID], error => {
    if (error) {
      response.status(355).json({ status: 'failed', message: 'Discussion Canceled' })
      throw error
    }
    response.status(201).json({ status: 'success', message: 'Discussion added.' })
  })
}
//API to get all discussions
const getDiscussions = (request, response) => {
  pool.query('SELECT * FROM discussions', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}
//API to get all WorkOrder
const getWorkOrder= (request, response) => {
  pool.query('SELECT * FROM WorkOrder', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}
//API to post new discussion
const postNewWorkOrder = (request, response) => {
  const {WorkOrderMonth, WorkOrderItem, ResId } = request.body

  pool.query('INSERT INTO WorkOrder (WorkOrderMonth, WorkOrderItem, ResId) VALUES ($1, $2, $3)', [WorkOrderMonth, WorkOrderItem, Resid], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'WorkOrder added.' })
  })
}
//API to post new comment
const postNewComment = (request, response) => {
  const { CommentBody, CommentTime, ResID, DisID  } = request.body

  pool.query('INSERT INTO Comments(CommentBody, CommentTime, resid, disid  ) VALUES ($1, $2, $3, $4)', [CommentBody, CommentTime, ResID, DisID  ], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'WorkOrder added.' })
  })
}
//API to get all WorkOrder
const getComments= (request, response) => {
  pool.query('SELECT * FROM Comments', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//API to post new fine
const postNewFine=(request, response) => {
  const {
  fineReason,
  fineAmount,
  AdmID,
  ResID  } = request.body

  pool.query('INSERT INTO Fines(fineReason, fineAmount, AdmID, ResID ) VALUES ($1, $2, $3, $4)', [fineReason, fineAmount, AdmID, ResID ], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'Fine added.' })
  })
}
//Api to get all Fines
const getFines= (request, response) => {
  pool.query('SELECT * FROM Fines', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}
//API to post new guest
const postNewGuest=(request, response) => {
  const { GuestName, CheckinTime, CheckedIn, ResID  } = request.body

  pool.query('INSERT INTO Guest(GuestName, CheckinTime, CheckedIn, ResID   ) VALUES ($1, $2, $3, $4)', [GuestName, CheckinTime, CheckedIn, ResID   ], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'Guest added.' })
  })
}
//API to get all guests
const getGuests= (request, response) => {
  pool.query('SELECT * FROM Guest', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

//API to post new alert
const postNewEmergencyAlert=(request, response) => {
  const { EmergencyCategory, EmergencyMessage, AdmID } = request.body

  pool.query('INSERT INTO EmergencyAlerts(EmergencyCategory, EmergencyMessage, AdmID) VALUES ($1, $2, $3)', [EmergencyCategory, EmergencyMessage, AdmID], error => {
    if (error) {
      throw error
    }
    response.status(201).json({ status: 'success', message: 'EmergencyAlerts added.' })
  })
}
//API to get all alerts
const getEmergencyAlert= (request, response) => {
  pool.query('SELECT * FROM EmergencyAlerts', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}
//API routes
//LoginSignUp
app
  .route('/Users')
  // GET endpoint
  .get(getUsers)
  // POST endpoint
  .post(addUser)

//Admin
app
  .route('/UserAdmin')
  .get(getAdminUsers)
  .post(signAdminUser)


//Users
app
  .route('/UserResident')
  .get(getResidentUsers)
  .post(signResidentUser)

//mockUsers
app
  .route('/mockUsers')

  .get(getMockUsers)


//discussions
app
  .route('/discussions')
  .get(getDiscussions)
  .post(postNewDiscussion)

//WorkOrder
app
  .route('/workorder')
  .get(getWorkOrder)
  .post(postNewWorkOrder)

//Comments
app
  .route('/comments')
  .get(getComments)
  .post(postNewComment)

//Fines
app
  .route('/fines')
  .get(getFines)
  .post(postNewFine)

//guests
app
  .route('/guests')
  .get(getGuests)
  .post(postNewGuest)

//
app
  .route('/emergencyalerts')
  .get(getEmergencyAlert)
  .post(postNewEmergencyAlert)

// Start server
app.listen(process.env.PORT || 3002, () => {
  console.log(`Server listening`)
})
