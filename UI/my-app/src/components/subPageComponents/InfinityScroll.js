
import { getStandart } from '../../fetches/StandartFetches';
import React, { useState, useEffect, useRef } from 'react';
import $ from 'jquery';
import Loader from './Loader';
function InfinityScroll(props) {
    const [list, setList] = useState([]);
    const hasMore = useRef(true)
    const moreBtnVisibility = useRef(false)
    const counterRef = useRef(1);
    const maxLegth = props.limit
    const inProcessRef = useRef(false);
  useEffect(() => {
    fetchNext();
    let elem = document.getElementById(props.id)
    elem.addEventListener("scroll", handleScroll);
  }, []);
  useEffect(() => {
    inProcessRef.current = false
  }, [list]);
  const fetchNext = () => {
    getStandart(props.fetchParams + (counterRef.current), (response) => {
      let maped = response.data.map(x => props.mapFunc(x))
      setList(oldArr => {
        hasMore.current = maped.length != 0
        moreBtnVisibility.current = oldArr.length >= maxLegth
        
        return [...oldArr, ...maped]
      })
    }, () => {})
    
  }
  const restart = () => {
    counterRef.current++
    getStandart(props.fetchParams + (counterRef.current), (response) => {
      let maped = response.data.map(x => props.mapFunc(x))
      setList(oldArr => {
        hasMore.current = maped.length != 0
        $(`#${props.id}`).scrollTop(0)
        moreBtnVisibility.current = false
        
        if(hasMore.current){
          return [...maped]
        } else{
          return [...oldArr]
        }
      })
    }, () => {})
    
  }
    const handleScroll = () => {
      console.log('has more', hasMore.current)
      if(inProcessRef.current == false && hasMore.current == true && moreBtnVisibility.current == false){
        let userScrollHeight = window.innerHeight + window.scrollY;
        let windowBottomHeight = document.documentElement.offsetHeight;
        let loadDot = parseInt((windowBottomHeight * 80) / 100)
  
        if (userScrollHeight >= windowBottomHeight || userScrollHeight >= loadDot) {
        inProcessRef.current = true
        counterRef.current++
        fetchNext();
        }
    }
  };
    return (
        <div id={`${props.id}`} style={{'height': `${props.height}px`, 'overflowY': 'scroll'}}>
            {list}
            <div style={{'display': 'flex', 'justifyContent': 'center'}}>
               <button className='btn markableBtn mb-3' onClick={() => {restart()}} style={{'display': `${moreBtnVisibility.current ? 'block': 'none'}`}}>más</button>
            </div>
            <div style={{'display': 'flex', 'justifyContent': 'center'}}>
                <div style={{'display': `${hasMore.current ? 'none' : 'block'}`}} className='mb-3 mt-2 infoText'>Eso es todo</div>
            </div>
            <Loader display={`${(moreBtnVisibility.current || !hasMore.current) ? 'none' : 'block'}`}></Loader>
        </div>
    )
}
export default InfinityScroll;