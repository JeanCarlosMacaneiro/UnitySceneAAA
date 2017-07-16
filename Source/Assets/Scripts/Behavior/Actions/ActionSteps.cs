using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class ActionSteps
{

    [SerializeField]
    public List<Action> actionSteps;

    private GameObject parentGameObject;
    private bool endVibrationObj;

    public void StartActionSteps(GameObject obj)
    {
        parentGameObject = obj;
        parentGameObject.GetComponent<MonoBehaviour>().StartCoroutine(OnAction());
    }

    private IEnumerator OnAction()
    {
        foreach (Action action in actionSteps)
        {
            yield return new WaitForSeconds(action.startDelay);

            switch (action.action)
            {
                case Constants.Actions.EnbleGameObject:
                    action.gameobject.SetActive(true);
                    break;
                case Constants.Actions.DisableGameObject:
                    action.gameobject.SetActive(false);
                    break;
                case Constants.Actions.PlayParticles:
                    if (action.gameobject.GetComponent<ParticleSystem>())
                    {
                        action.gameobject.GetComponent<ParticleSystem>().Play();
                    }
                    break;
                case Constants.Actions.StopParticles:
                    if (action.gameobject.GetComponent<ParticleSystem>())
                    {
                        action.gameobject.GetComponent<ParticleSystem>().Stop();
                    }
                    break;
                case Constants.Actions.StartAnimationBool:
                    if (action.gameobject.GetComponent<Animator>())
                    {
                        action.gameobject.GetComponent<Animator>().SetBool(action.animationProperty, true);
                    }
                    break;
                case Constants.Actions.StopAnimationBool:
                    if (action.gameobject.GetComponent<Animator>())
                    {
                        action.gameobject.GetComponent<Animator>().SetBool(action.animationProperty, false);
                    }
                    break;
                case Constants.Actions.StartAnimationTrigger:
                    if (action.gameobject.GetComponent<Animator>())
                    {
                        action.gameobject.GetComponent<Animator>().SetTrigger(action.animationProperty);
                    }
                    break;
                //case Constants.Actions.CallMethod:
                //    callMethods(action.methods);
                //    break;
                case Constants.Actions.DisableComponetBoxCollider:
                    action.gameobject.GetComponent<BoxCollider>().enabled = false;
                    break;
            }
        }
    }

    //private void callMethods(EventTrigger.TriggerEvent methods)
    //{
    //    if (methods.GetPersistentEventCount() > 0)
    //    {
    //        for (int i = 0; i < methods.GetPersistentEventCount(); i++)
    //        {
    //            MethodInfo methodInfo = methods.GetPersistentTarget(0).GetType().GetMethod(methods.GetPersistentMethodName(0));
    //            methodInfo.Invoke(methods.GetPersistentTarget(0), null);
    //        }
    //    }
    //}
}
