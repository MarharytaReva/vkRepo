import {apiUrl} from './fetches/StandartFetches'

let meses = [
   'Enero',
   'Febrero',
   'Marzo',
   'Abril',
   'Mayo',
   'Junio',
   'Julio',
   'Agosto',
   'Septiembre',
   'Octubre',
   'Noviembre',
   'Diciembre'
]

function dateToStr(date){
    date = new Date(date)
    var mm = meses[date.getMonth()];
    var dd = date.getDate();
    var yy = date.getFullYear();
    return `el ${dd} de ${mm} de ${yy}` 
}

function getMadiaUrl(mediaObj){
    return apiUrl + `/media/${mediaObj.directory}/${mediaObj.fileName}/${mediaObj.extension}`
}
export {dateToStr, getMadiaUrl}