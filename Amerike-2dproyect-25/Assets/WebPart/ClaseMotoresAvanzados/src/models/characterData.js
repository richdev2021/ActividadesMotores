import mongoose from "mongoose";

const schema = new mongoose.Schema({
  MoveSpeed:{
    type: Number,
    required: true,
    unique: false
  },
  JumpForce:{
    type: Number,
    required: true,
    unique: false
  },
  StyleName:{
    type: String,
    required: true,
    unique: false
  }
});

export default mongoose.model("CharacterData",schema);