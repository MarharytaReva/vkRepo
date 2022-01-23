
import React from 'react'
import { getStandart } from '../../../fetches/StandartFetches';
import InfoLine from './InfoLine'
import  {dateToStr}  from '../../../functions'
import $ from "jquery";
let defaultSign = 'no está lleno'


class UserInfoComponent extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            status: '',
            country: '',
            city: '',
            birthday: '',
            genderName: '',
            email: '',
            phone: '',
            nativeCity: '',
            nativeCountry: '',
            additional: '',
            workPlace: '',
            studyPalce: '',
            isOpened: false,
            sign: 'Más'
        }
        this.infoId = 5;
    }
    moreOrLessClickHandler() {
        this.setState(prev => {
            let isOpen = !prev.isOpened
            return {
                ...prev,
                isOpened: isOpen,
                sign: isOpen ? 'Menos' : 'Más'
            }
        })
        $( ".forOpen" ).fadeToggle('slow')
    }
    getUserInfo(data) {
        this.setState(prev => {
            return {
                ...prev,
                status: data.status == null ? defaultSign : data.status,
                country: data.currentCountry == null ? defaultSign : data.currentCountry,
                city: data.currentCity == null ? defaultSign : data.currentCity,
                birthday: dateToStr(data.birthday),
                email: data.email == null ? defaultSign : data.email,
                phone: data.phone == null ? defaultSign : data.phone,
                nativeCity: data.city == null ? defaultSign : data.city,
                nativeCountry: data.country == null ? defaultSign : data.country,
                additional: data.additional == null ? defaultSign : data.additional,
                workPlace: data.workPlace == null ? defaultSign : data.workPlace,
                studyPalce: data.studyPalce == null ? defaultSign : data.studyPalce,
                genderName: data.gender.genderName
            }
        })
    }
    errorUserInfo() {
        this.setState(prev => {
            return {
                ...prev,
                status: defaultSign,
                country: defaultSign,
                city: defaultSign,
                birthday: defaultSign,
                email: defaultSign,
                phone: defaultSign,
                nativeCity: defaultSign,
                nativeCountry: defaultSign,
                additional: defaultSign,
                workPlace: defaultSign,
                studyPalce: defaultSign,
                genderName: defaultSign
            }
        })
    }
    componentDidMount() {
        getStandart('/userinfo/' + this.infoId,
            (data) => { this.getUserInfo(data) },
            () => { this.errorUserInfo() })
    }
    render() {
        return (
            <>
                <p className="fw-light">{this.state.status}</p>

                <div className="hr"></div>

                <table className="w-100">
                    <tbody>
                        <InfoLine propName="País" info={this.state.country} />
                        <InfoLine propName="Ciudad" info={this.state.city} />
                        <InfoLine propName="Cumpleaños" info={this.state.birthday} />  

                        <InfoLine className="forOpen" propName="Teléfono" info={this.state.phone} />
                        <InfoLine className="forOpen" propName="Correo electrónico" info={this.state.email} />
                        <InfoLine className="forOpen" propName="Género" info={this.state.genderName} />
                        <InfoLine className="forOpen" propName="País de origen" info={this.state.nativeCountry} />
                        <InfoLine className="forOpen" propName="Ciudad de origen" info={this.state.nativeCity} />
                        <InfoLine className="forOpen" propName="Sobre mí" info={this.state.additional} />
                        <InfoLine className="forOpen" propName="Lugar de estudio" info={this.state.studyPalce} />
                        <InfoLine className="forOpen" propName="Trabajo" info={this.state.workPlace} />
                    </tbody>
                </table>

                <div className="cenerAlignClass">
                    <button type="button" onClick={() => this.moreOrLessClickHandler()} className="btn btn-link myLink">{this.state.sign}</button>
                </div>
            </>
        )
    }
}

export default UserInfoComponent