﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ubiq.XR
{
    public interface IGraspable
    {
        void Grasp(Hand controller, Collider collider);
        void Release(Hand controller);
    }


}
