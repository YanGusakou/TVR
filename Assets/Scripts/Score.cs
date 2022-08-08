using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  public Text textScore;
  public Score enemyScore;


  public bool isBlue = false;

  private int score = 0;
  private void Start() 
  {
    textScore.text = "0";
  }
  IEnumerator TimeCoroutine()
    {
      var s = GameObject.Find("Puck").GetComponent<Puck>();
      s.rigidbody.velocity = Vector2.zero;
      yield return new WaitForSeconds(3f);
      s.ResetPuck();
      enemyScore.Reset();
      this.Reset();
      var p1 = GameObject.Find("Player1").GetComponent<Player1>();
      p1.ResetPlayer1();
      var p2 = GameObject.Find("Player2").GetComponent<Player2>();
      p2.ResetPlayer2();
    }


  public void Reset(){
    score = 0;
    textScore.text = score.ToString();
  }
  private  void OnTriggerEnter2D(Collider2D other) 
  {
    if(other.CompareTag("Player"))
    {
      if(score < 2)
      {
          score++;
          textScore.text = score.ToString();
          var s = (Puck) other.GetComponent("Puck");
          s.ResetPuck();
          var p1 = GameObject.Find("Player1").GetComponent<Player1>();
          p1.ResetPlayer1();
          var p2 = GameObject.Find("Player2").GetComponent<Player2>();
          p2.ResetPlayer2();
        }
        else
        {
          textScore.text = isBlue ? "Blue WON!" :  "Red WON!";
          StartCoroutine(TimeCoroutine());
        }
    }
  }
}

// score++;
//       textScore.text = score.ToString();
//       var s = (Puck) other.GetComponent("Puck");
//       s.ResetPuck();
//       var p1 = GameObject.Find("Player1").GetComponent<Player1>();
//       p1.ResetPlayer1();
//       var p2 = GameObject.Find("Player2").GetComponent<Player2>();
//       p2.ResetPlayer2();


// private  void OnTriggerEnter2D(Collider2D other) 
//   {
//     if(other.CompareTag("Player"))
//     {
//       if(score == 2)
//       {
//         score = 0;
//         if(this.CompareTag("BlueSide"))
//         {
//           textScore.text = "Red Won!";
//           var s = (Puck) other.GetComponent("Puck");
//           s.ResetPuck();
//           var p1 = GameObject.Find("Player1").GetComponent<Player1>();
//           p1.ResetPlayer1();
//           var p2 = GameObject.Find("Player2").GetComponent<Player2>();
//           p2.ResetPlayer2();
//         }
//         else
//         {
//           textScore.text = "Blue Won!";
//           var s = (Puck) other.GetComponent("Puck");
//           s.ResetPuck();
//           var p1 = GameObject.Find("Player1").GetComponent<Player1>();
//           p1.ResetPlayer1();
//           var p2 = GameObject.Find("Player2").GetComponent<Player2>();
//           p2.ResetPlayer2();
//         }
//       }
//       else
//       {
//       score++;
//       textScore.text = score.ToString();
//       var s = (Puck) other.GetComponent("Puck");
//       s.ResetPuck();
//       var p1 = GameObject.Find("Player1").GetComponent<Player1>();
//       p1.ResetPlayer1();
//       var p2 = GameObject.Find("Player2").GetComponent<Player2>();
//       p2.ResetPlayer2();
//       }
//     }
//   }
// }
