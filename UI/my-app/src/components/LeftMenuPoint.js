
import { Link } from "react-router-dom";
function LeftMenuPoint(props){
    return(
        <div className="row mb-xs-5 mt-xs-5 mb-sm-5 mt-sm-5 mt-md-4 mb-md-4 mb-lg-2 mt-lg-2 mb-xl-2 mt-xl-2">
        <div className="d-flex flex-nowrap" >
            <div style={{textAlign: 'right'}}>
                <Link to={`${props.path}`}>
                <img src={props.img} className="icon"/>
                </Link>
                
            </div>
        
        <div className="d-none d-xl-block d-lg-block">
            <Link to={`${props.path}`} style={{color: 'black', textDecoration: 'none'}}>
            <p className="fw-normal ms-2 leftMenuPoint" >{props.sign}</p>
            </Link>
        </div>
      </div>
      </div>
    )
}

export default LeftMenuPoint