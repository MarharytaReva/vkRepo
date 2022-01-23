

function InfoLine(props){
    return(
        <tr className={`${props.className}`}>
            <td className="fw-normal w-40">{props.propName}</td>
            <td className="fw-normal infoText w-60">{props.info}</td>
        </tr>
    )
}
export default InfoLine