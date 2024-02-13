import React, { ReactElement, FC, useState, useEffect } from "react";
import { Avatar, Box, Button, Stack, Typography } from "@mui/material";
import { IGetResource } from "../Models/getResource.model";
import axios from "axios";
import { Item } from "../style/Item"

const reqres = 'https://reqres.in/';

const Resources: FC<any> = (): ReactElement => {

  const [reqresResponse, setReqresResponse] = useState<IGetResource | null>(null)
  const [isShown, setIsShown] = useState(false);

  const handleClick = () => {
    setIsShown(current => !current);
  };

  useEffect(() => {
    axios.get<IGetResource>(`${reqres}api/unknown/2`)
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
        <Typography variant="h3">Click here to show single resource</Typography>
      </Button>
      {isShown && reqresResponse && <Stack spacing={2}>
        <Item>get single recource :</Item>
        <Item>Id: {reqresResponse.data.id}</Item>
        <Item>Name: {reqresResponse.data.name}</Item>
        <Item>Year: {reqresResponse.data.year}</Item>
        <Item>Pantone_value: {reqresResponse.data.pantone_value}</Item>
        <Item>Color:  <div style={{ backgroundColor: reqresResponse.data.color }}>why is not color displayed untill I put some text into div???</div></Item>
        <Item>Text: {reqresResponse.support.text}</Item>
        <Item>Url: {reqresResponse.support.url}</Item>
      </Stack>
      }
    </Box>
  );
};

export default Resources;