import { useParams } from "react-router-dom"
import { getPracticeAreaById } from "../../api"
import { useQuery } from "@tanstack/react-query"
import styles from "./styles.module.css"
import Loading from "../../components/Loading"

function PracticeArea() {

    const params = useParams("id")
    const query = useQuery( {queryKey: ["practiceArea", params.id], queryFn: () => getPracticeAreaById(params.id)});

    if(query.isLoading){
        return <div><Loading /></div>
    }

    const practiceArea= query.data.data;
    
  return (
    <div className={styles.practiceArea}>
        <div className={styles.title}>
            <h1>{practiceArea.name}</h1>
        </div>
        
        <div className={styles.content}>
            <div>
                <img src="/assets/carousel/slide1.jpg"></img>
            </div>
                <p>
                  {practiceArea.description}
                </p>
            </div>
    </div>
  )
}

export default PracticeArea