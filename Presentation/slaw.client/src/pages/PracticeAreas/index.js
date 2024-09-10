import { useQuery } from "@tanstack/react-query"
import Card from "../../components/Card"
import styles from "./styles.module.css"
import { getPracticeAreas } from "../../api"
import Loading from "../../components/Loading";
import { useEffect } from "react";

function PracticeAreas() {
  const query = useQuery({queryKey: ["practiceAreas"], queryFn: getPracticeAreas})

  if(query.isLoading){
    return <div><Loading /></div>
  }
  
  const practiceAreas = query.data.data;

  return (
    <div className={styles.practiceAreas}>
      <div className={styles.title}><h1>UZMANLIK ALANLARI</h1></div>
      <div className={styles.content}>
      {
        practiceAreas.map((item, key) => <Card item = {item} key={key}/>)
      }
      </div>

    </div>
  )
}

export default PracticeAreas