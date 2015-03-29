"use strict";

var appConfig = require("./app/config");
var express = require('express');
var app = express();
var path = require('path');
var util = require("util");
var bodyParser = require('body-parser');
var databaseHelper = require("dal");

var LocationController = require("./app/controllers/location-controller");
var locationController = new LocationController();

app.use(bodyParser.json()); 

app.get('/', function (req, res) {
  res.send("Hello!");
});

app.post('/location', locationController.updateLocation);
app.get('/location/recent', locationController.getRecentEntries);
app.delete('/location/:ids', locationController.deleteDocuments)

console.log("Starting Mongo..");

databaseHelper.startMongo(appConfig.db, function (err, db) {
  if (err) {
    console.log("Error Starting Mongo..");
    console.log(err);
    console.log("Exiting...");
  } else {
    console.log("Successfully connected to Database... Starting Node...");
    var port = process.env.PORT || appConfig.node.port;
    app.listen(port);
    console.log(port);
  }
});