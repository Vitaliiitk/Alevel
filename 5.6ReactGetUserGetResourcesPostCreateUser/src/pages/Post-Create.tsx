import React, { ReactElement, FC, useState, useEffect } from "react";
import { Box, Button, Stack, Typography } from "@mui/material";
import axios from "axios";
import { ICreateUser } from "../Models/createUser.model";
import { Item } from "../style/Item";
import { IReqresUserPostResponse } from "../Models/postAfterCreationUser";

const reqres = 'https://reqres.in/';
const PostCreate: FC<any> = (): ReactElement => {

  const [isShown, setIsShown] = useState(false);
  const [reqresResponsePost, setReqresResponsePost] = useState<IReqresUserPostResponse | null>(null)

  const handleClick = () => {
    
      axios.post<IReqresUserPostResponse>(`${reqres}api/users`, 
      {name: 'morpheus',  job: 'leader' } as ICreateUser)
        .then(response => {
          console.log(response.data);
          setReqresResponsePost(response.data);
        });

    setIsShown(current => !current);
  };
  
  return (
    <Box
      sx={{
        flexGrow: 1,
        backgroundColor: "whitesmoke",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Button onClick={handleClick}>
      <Typography variant="h3">Click to make post create user operation</Typography>
      </Button>
      {reqresResponsePost && <Stack spacing={2}>
        <Item>Create this user:</Item>
        <Item>Name: {reqresResponsePost.name}</Item>
        <Item>Job: {reqresResponsePost.job}</Item>
        <Item>Id: {reqresResponsePost.id}</Item>
        <Item>Created at: {reqresResponsePost.createdAt}</Item>
      </Stack>
      }
      
    </Box>
  );
};

export default PostCreate;