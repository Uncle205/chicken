// var timerId=setInterval(function(){
//   console.log('test');
// },2000);



 // var func = require('./func');
 // func.test(1,1);

 var fs=require('fs');
 // var mread = fs.createReadStream(__dirname + '/main.html', 'utf8');
 // var mwrite = fs.createWriteStream(__dirname+'/main.html');
 // mread.pipe(mwrite);
 // mread.on('data', function(block){
 //   console.log('========:')
 // })
// var myFiletext = fs.readFileSync('text.txt', 'utf8');
// console.log(myFiletext);
//
// fs.writeFileSync('text2.txt', myFiletext);

// var http = require('http');
// var server = http.createServer(function(req, res){
//
//   if(req.url=='/news'){
//       res.writeHead(200, {'Content-Type': 'text/html; charset=utf-8'});
// fs.createReadStream(__dirname+'/main.html').pipe(res);
//       // res.end();
//
//
//   }
//   else{
//     res.writeHead(200, {'Content-Type': 'text/plain; charset=utf-8'});
//     fs.createReadStream(__dirname+'main2.html').pipe(res);
//   }
// });
//
// console.log('listen 3000');
// console.log('127.0.0.1'+req.url);

 // server.listen(3000, '127.0.0.1');
 var express = require('express');
 const mongoose = require('mongoose');

 mongoose.connect('mongodb://User:qwerty1@ds241530.mlab.com:41530/shop',  {useNewUrlParser: true });
var db = mongoose.connection;
 var exp = express();

exp.set('view engine', 'ejs');
var mysql = require('mysql');

var con = mysql.createConnection({
  host: "82.200.170.122",
  user: "testuser",
  password: "qwerty123123",
  database: "test"
});

con.connect(function(err){
  var sql ="INSERT INTO profile (name, address) VALUES ('Company Inc', 'Highway 37')";
  con.query(sql, function (err, result){
    if(err) throw err;
    console.log("1 record inserted");
  });
  con.query("SELECT * FROM users", function(err, result, fields){
    if(err)throw err;
    console.log(result);
  });
});
  var ObjectId = require('mongodb').ObjectId;

//  exp.get('/', function(req, res){
//    res.send('Test 123');
//  });
//  exp.get('/news/:news_id', function(req,res){
//    res.send(req.params.news_id);
//  });
// <h1>NEWS_ID: <%=news_id%> </h1> -->
exp.use('/public', express.static('public'));
  // exp.get('/news/:news_id', function(req,res){

  // res.render('index2', {news_id: req.params.news_id});
  // });
var bodyParser = require('body-parser');
var urlencodeParser =bodyParser.urlencoded({extended:false});
//let b;
  exp.get('/login',urlencodeParser, function(req,res){
    res.render('index2', {id: 123});
  });
  exp.get('/menu',urlencodeParser, function(req,res){
    res.render('menu');
  });
//   exp.get('/secret',urlencodeParser, function(req,res){
// let b;
//     db.once('open', function(){
//       console.log("we are connected!");
//       db.collection('users').find({}, {limit:10}).toArray(function(err, docs){
//          b=docs;
//         console.dir(docs);
//       });
//
//     });
//   res.render('menu', {values: b});
//   // res.send(b);
//   });
  exp.post('/login', urlencodeParser, function(req,res){
    res.render('index2');
    a=req.body
    var user={
      Values: a,
      _id: new ObjectId()
    };
      db.collection('users').insertOne(user);
    console.log(req.body);
  });

  db.on('error', console.error.bind(console, 'connection error'));








 exp.listen(3000);
