var request = require("request");
var Temp = 10;
Temp = Temp+1;

function tempRise() {
  Temp = Temp + 1;
  if (Temp > 80) {
    Temp = 10;
  }
};

function postevent() {
  var options = {
      url: "https://api.tago.io/v0/data",
      method: "POST",
      headers: {
        'Device-Token': 'f8154f30-9871-11e4-a70d-19968a886783',
        'Content-Type': 'application/x-www-form-urlencoded',

      },
      form: {
        variable: "temperature",
        value: Temp,
      }
  };

  request.post(options, function(error, response, body) {
    console.log(body);
    console.log(error);
    //console.log(response);
  });
};

var intvl = setInterval(function() {
  postevent();
}, 5000);

var intvl_temp = setInterval(function() {
  tempRise();
}, 5000);
