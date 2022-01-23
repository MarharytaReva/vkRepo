import React from 'react';
import { Link } from "react-router-dom"
import LeftMenuPoint from './LeftMenuPoint';
class LeftMenu extends React.Component{
  constructor(props){
    super(props)
  }
  render(){
    return(
      <div className="container">
        <LeftMenuPoint img={process.env.PUBLIC_URL + '/news.png'} path="/" sign="Noticias"/>
        <LeftMenuPoint img={process.env.PUBLIC_URL + '/user.png'} path="/" sign="Mi página"/>
    </div>
    )
  }
   
}

export default LeftMenu