import {startStandaloneServer} from '@apollo/server/standalone';
import mongoose from 'mongoose';
import { server } from './server.js';

const username = 'StormDB';
const password = 'sJgXs14W7OLynF9y';
const dbname = 'amk25db';
const port = '4000';
const host = 'localhost';
const serverUrl = `http://${host}:${port}/graphql`;
const uri = `mongodb+srv:/${username}:${password}@clusterstorm.mcenx.mongodb.net/${dbname}?retryWrites=true&w=majority&appName=Cluster0`;

mongoose.connect(uri).then(()=>{
    startStandaloneServer(server,{
        listen: {port}
    }).then(()=>{
        console.log(`Runing server at> ${serverUrl}`)
    })
})
