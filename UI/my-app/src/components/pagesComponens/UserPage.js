
import React from 'react';
import { getStandart } from '../../fetches/StandartFetches';
import UserInfoComponent from '../subPageComponents/userPageComponents/UserInfoComponent';
import { getMadiaUrl } from '../../functions'
import InfinityScroll from '../subPageComponents/InfinityScroll';
class UserPage extends React.Component{
    constructor(props){
        super(props)
        this.state = {
            name: '',
            ava: {
              direcory: '',
              fileName: '',
              extension: ''
            }
        }
        this.userId = 5;
        //
    }
    componentDidMount(){
       
        getStandart('/user/' +  this.userId, (data) => {
            this.setState({
              name: data.name,
              ava: data.ava
            })
        }, () => {})
    }
    render(){
        return(
            <>
             <div className="container  w-100" style={{margin: '0em'}}>
          <div className="row withoutMagin"> 
            <div className="col-lg-4 col-xl-4 d-none d-xl-block d-lg-block">
              <div style={{marginLeft: '0'}}>
                <div >
                    <img className="profilePhoto" src={getMadiaUrl(this.state.ava)}/>
                </div>
                <button type="button" className="btn btn-light myLink mt-3" style={{width: '100%'}}>Edit</button>
              </div>
            </div>
            <div className="col-lg-8 col-xl-8 col-md-12 col-sm-12 col-xs-12 p-md-0 p-sm-0 p-xm-0 m-sm-0 m-xs-0 m-md-0 w-sm-100 w-xs-100 x-md-100">
              <div className="w-sm-100 w-xs-100 x-md-100" style={{marginRight: '0em'}}>
                <img src={getMadiaUrl(this.state.ava)} className="profilePhoto d-inline d-lg-none d-xl-none circleAvaMain"/>
                <p className="fs-4 d-inline">{this.state.name}<button type="button" className="btn btn-light d-inline d-lg-none d-xl-none myLink mt-3" style={{width: '100%'}}>Edit</button></p>
              
              <UserInfoComponent />

                <div className="hr"></div>
                <div className="container mt-3">
                  <div className="row">
                    <div className="col numericCol">
                      <div className="infoText">100</div>
                      <p className="fw-light">prop</p>
                    </div>
                    <div className="col numericCol">
                      <div className="infoText">100</div>
                      <p className="fw-light">prop</p>
                    </div>
                    <div className="col numericCol">
                      <div className="infoText">100</div>
                      <p className="fw-light">prop</p>
                    </div>
                    <div className="col numericCol">
                      <div className="infoText">100</div>
                      <p className="fw-light">prop</p>
                    </div>
                    <div className="col numericCol">
                      <div className="infoText">100</div>
                      <p className="fw-light">prop</p>
                    </div>
                  </div>
                </div>
            </div>
            <InfinityScroll height={window.screen.height} id={'lentaTest'} limit={20} fetchParams={'/comment/'} mapFunc={function(item){
              return <div key={"lenta" + item.id} style={{padding: "10rem"}}>{item.text}</div>
            }}/>
            </div>
          </div>
          </div>
            </>
        )
    }
}

export default UserPage