import { Avatar, Box, Paper, Typography, styled } from "@mui/material";


export const Item = styled(Paper)(({ theme }) => ({
  
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
   
    color: theme.palette.text.secondary,
    
    '&::before': {
      content: '""',
      display: 'block',
      height: '20px', // Adjust height as needed for spacing
    },
  }));