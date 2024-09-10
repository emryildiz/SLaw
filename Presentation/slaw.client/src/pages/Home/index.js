import styles from "./styles.module.css"
import { Carousel } from 'antd';
import { useQuery } from "@tanstack/react-query"
import { getPracticeAreas } from "../../api";
import Card from "../../components/Card"
import Loading from "../../components/Loading";

function Home() {
    
    const query = useQuery({queryKey: ["practiceAreas"], queryFn: getPracticeAreas})

    if(query.isLoading){
      return <div><Loading /></div>
    }
    
    const practiceAreas = query.data.data;
    const firstThreeItems = practiceAreas.slice(0,3);

  return (
    <div className={styles.home}>
      <Carousel className={styles.carousel}>
        <div className={`${styles.slideOne} ${styles.slideContent}`}>
            <h1>Lorem ipsum</h1>
            <p>Lorem ipsum dolor sit amet</p>
            <button>Daha fazla</button>
        </div>
        <div className={`${styles.slideTwo} ${styles.slideContent}`}>
            <h1>Lorem ipsum</h1>
            <p>Lorem ipsum dolor sit amet</p>
            <button>Daha fazla</button>
        </div>
        <div className={`${styles.slideThree} ${styles.slideContent}`}>
            <h1>Lorem ipsum</h1>
            <p>Lorem ipsum dolor sit amet</p>
            <button>Daha fazla</button>
        </div>
      </Carousel>

        <div className={styles.practiceAreas}>
            <h1 className={styles.title}>Faaliyetlerimiz</h1>
            <div className={styles.cards}>
                {
                    firstThreeItems.map((item, key) => <Card item={item} key={key} />)
                }
            </div>
        </div>

        <div className={styles.articles}> 
            <h1 className={styles.title}>Makalelerimiz</h1>
            <div className={styles.cards}>
                {
                    firstThreeItems.map((item, key) => <Card item={item} key={key} />)
                }
            </div> 
        </div>
    </div>
  )
}

export default Home