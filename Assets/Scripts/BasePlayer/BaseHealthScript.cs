using UnityEngine;
using System.Collections;

public  class BaseHealthScript : MonoBehaviour
{
    [SerializeField]
    int _health = 24;

    #region properties

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    #endregion


    #region methods

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
            Destroy(this.gameObject);
    }

    #endregion

}
