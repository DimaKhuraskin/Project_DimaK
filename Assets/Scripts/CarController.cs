using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Структура для описания колес
    [System.Serializable]
    public struct WheelInfo
    {
        // Трансформация колеса
        public Transform visualwheel;
        // Коллайдер колеса
        public WheelCollider wheelcollider;
    }

    // Характеристики автомобиля
    [SerializeField]
    private float _motor = 800, _steer = 50, _brake = 440, _motorNitro = 10000;
    private float _motorCar = 0;

    // Колеса автомобиля
    [SerializeField]
    private WheelInfo _FL, _FR, _BL, _BR;

    // Оси движения 
    private float _vert;
    private float _horz;

    // Позиция колеса
    private Vector3 _position;
    // Поворот колеса
    private Quaternion _rotation;

    [SerializeField]
    private AudioSource _idleSound, _movementSound, _nitroSound, _brakeSound;

    [SerializeField]
    private List<ParticleSystem> _brakeParticle = new List<ParticleSystem>();

    [SerializeField]
    private List<ParticleSystem> _nitroParticle = new List<ParticleSystem>();

    private void Update()
    {
        // Получаем значение оси
        _vert = Input.GetAxis("Vertical");
        _horz = Input.GetAxis("Horizontal");
        if(_vert > 0)
        {
            _idleSound.Pause();
            _movementSound.UnPause();
        }
        else
        {
            _idleSound.UnPause();
            _movementSound.Pause();
        }
        
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Jump"))
        {
            _motorCar = _motorNitro;
            for (int i = 0; i < _nitroParticle.Count; i++)
            {
                _nitroParticle[i].Play();
            }
            if (!_nitroSound.isPlaying)
            {
                _nitroSound.PlayOneShot(_nitroSound.clip);
            }
        }
        else
        {
            _motorCar = _motor;
            for (int i = 0; i < _nitroParticle.Count; i++)
            {
                _nitroParticle[i].Stop();
            }
        }
        // Тормоз
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _FL.wheelcollider.brakeTorque = _brake;
            _FR.wheelcollider.brakeTorque = _brake;
            _BL.wheelcollider.brakeTorque = _brake;
            _BR.wheelcollider.brakeTorque = _brake;
            if(!_brakeSound.isPlaying && gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.5)
            {
                _brakeSound.PlayOneShot(_brakeSound.clip);
            }
            for(int i = 0; i < _brakeParticle.Count; i++)
            {
                _brakeParticle[i].Play();
            }
        }
        else
        {
            _FL.wheelcollider.brakeTorque = 0;
            _FR.wheelcollider.brakeTorque = 0;
            _BL.wheelcollider.brakeTorque = 0;
            _BR.wheelcollider.brakeTorque = 0;

            for (int i = 0; i < _brakeParticle.Count; i++)
            {
                _brakeParticle[i].Stop();
            }
        }

        _FL.wheelcollider.steerAngle = _horz * _steer;
        _FR.wheelcollider.steerAngle = _horz * _steer;
        _BL.wheelcollider.motorTorque = _vert * _motor;
        _BR.wheelcollider.motorTorque = _vert * _motor;

        UpdateVisualWheels();
    }
    private void UpdateVisualWheels()
    {


        _FL.wheelcollider.GetWorldPose(out _position, out _rotation);
        _FL.visualwheel.position = _position;
        _FL.visualwheel.rotation = _rotation;

        _FR.wheelcollider.GetWorldPose(out _position, out _rotation);
        _FR.visualwheel.position = _position;
        _FR.visualwheel.rotation = _rotation;

        _BL.wheelcollider.GetWorldPose(out _position, out _rotation);
        _BL.visualwheel.position = _position;
        _BL.visualwheel.rotation = _rotation;

        _BR.wheelcollider.GetWorldPose(out _position, out _rotation);
        _BR.visualwheel.position = _position;
        _BR.visualwheel.rotation = _rotation;
    }

}
