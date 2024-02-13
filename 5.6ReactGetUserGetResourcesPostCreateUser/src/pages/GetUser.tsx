import React, { ReactElement, FC, useEffect, useState } from "react";
import { Avatar, Box, Button, Typography } from "@mui/material";
import Stack from '@mui/material/Stack';
import axios from "axios";
import { IGetUser } from "../Models/getUser.model";
import { Item } from "../style/Item"

const reqres = 'https://reqres.in/';

const GetUser: FC<any> = (): ReactElement => {

  const [reqresResponse, setReqresResponse] = useState<IGetUser | null>(null)
  const [isShown, setIsShown] = useState(false);

  const handleClick = () => {
    setIsShown(current => !current);
  };

  useEffect(() => {
    axios.get<IGetUser>(`${reqres}api/users/2`)
      .then(response => {
        console.log(response.data);
        setReqresResponse(response.data);
      })
  }, []);

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
        <Typography variant="h3">Click to show user</Typography>
      </Button>
      
      {isShown &&reqresResponse &&
        <Stack spacing={2} >
          <Item>get api/users/2 :</Item>
          <Item>Id: {reqresResponse.data.id}</Item>
          <Item>First name: {reqresResponse.data.first_name}</Item>
          <Item>Last name: {reqresResponse.data.last_name}</Item>
          <Item>Email: {reqresResponse.data.email}</Item>
          <Item >
            Avatar: property positioning: "relative", left:"50%" виглядає зовсім не посередині 
            <Avatar alt={reqresResponse.data.first_name + " " + reqresResponse.data.last_name}
            src={reqresResponse.data.avatar}
            sx={{ width: 100, height: 100, left : "50%",}}/></Item>
          <Item>Text: {reqresResponse.support.text}</Item>
          <Item>Url: {reqresResponse.support.url}</Item>
        </Stack>
      }

    </Box>
  );
};

export default GetUser;