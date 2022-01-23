import { Switch, Route, BrowserRouter as Router } from 'react-router-dom'
import Nav from './Nav'
import UserPage from './pagesComponens/UserPage'
import LeftMenu from './LeftMenu'

function App() {
    return (
        <>
            <Router>
            <Nav></Nav>
            <div className="container p-xm-0 p-sm-0 p-md-0 m-0 w-100">
                <div className="row h-100">
                    <div className="bg-light col-lg-3 col-xl-3 col-xs-2 col-sm-2 col-md-2 pt-3">
                        <LeftMenu></LeftMenu>
                    </div>

                    <div className="col-lg-9 col-xl-9 col-sm-10 col-xs-10 col-md-10 pt-3" style={{ backgroundColor: 'white' }}>
                        
                            <Switch>
                                <Route exact path='/' component={UserPage}></Route>
                               
                                <Route component={UserPage}></Route>
                            </Switch>
                        
                    </div>
                </div>
            </div>
            </Router>
        </>
    )
}

export default App