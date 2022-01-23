
import React from 'react';

class Nav extends React.Component{
  constructor(props){
    super(props)
  }
  render(){
    return(
      <nav className="navbar sticky-top navbar-expand-lg navbar-light" style={{paddingLeft: '8vw', background: 'white'}}>
      <div className="container-fluid">
        <a className="navbar-brand" href="#"><span className="brandBlue">Com</span><b>parte</b></a>
      </div>  
    </nav>
  )
  }
    
}

export default Nav