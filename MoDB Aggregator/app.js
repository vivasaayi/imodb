"use strict";

var appConfig = require("./app/config");
var express = require('express');
var app = express();
var path = require('path');
var util = require("util");
var bodyParser = require('body-parser');
var databaseHelper = require("./app/repositories/database-heler");

var LocationController = require("./app/controllers/location-controller");
var SensorsController = require("./app/controllers/sensors-controller");
var DevicesController = require("./app/controllers/devices-controller");

var locationController = new LocationController();
var sensorsController = new SensorsController();
var devicesController = new DevicesController();

app.use(bodyParser.json()); 

app.get('/', function (req, res) {
  res.send("Hello!");
});

app.post('/location', locationController.updateLocation);
app.get('/location', locationController.getRecentEntries);

app.get('/sensors', sensorsController.getAllSensors);
app.get('/sensors/:id', sensorsController.getLocationUpdatesBySensor);

app.get('/devices', devicesController.getAllDevices);

console.log("Starting Database..");

databaseHelper.startDatabase(appConfig.db, function (err, db) {
  if (err) {
    console.log("Error Starting/Connecting to Database..");
    console.log(err);
    console.log("Exiting...");
  } else {
    console.log("Successfully connected to Database... Starting Node...");
    var port = appConfig.node.port;
    app.listen(port);
    console.log(port);
  }
});