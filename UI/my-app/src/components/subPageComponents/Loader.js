import '../../css/loader.css'
function Loader(props) {
    return (
        <div style={{'display': `${props.display}`}}>
            <div style={{ 'display': 'flex', 'justifyContent': 'center' }}>
                <div class="lds-ellipsis"><div></div><div></div><div></div><div></div></div>
            </div>
        </div>
    )
}
export default Loader